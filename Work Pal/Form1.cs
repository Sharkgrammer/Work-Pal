using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Work_Pal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Gloabal vars here
        private Stopwatch stopwatch;
        private TimeSpan weekTime, dayTime;
        private MySqlConnection connection = null;
        private DateTime today;
        private String MySqlFormatter = "yyyy-MM-dd";
        private int overall_week_id, overall_day_id;
        private const long TicksPerMillisecond = 10000;

        private void Form1_Load(object sender, EventArgs e)
        {
            today = DateTime.Today;
            date.Text = today.ToString("dddd, MMMM dd, yyyy");

            stopwatch = new Stopwatch();

            if (accessDatabase())
            {
                int daysFromMonday = (DayOfWeek.Monday - today.DayOfWeek - 7) % 7;
                DateTime monday = today.AddDays(daysFromMonday);

                int week_id = checkWeek(monday);
                checkDay(week_id);
                checkPreviousDays(monday, week_id);
                checkGraph();

                timeWeek.Text = getTimeString(weekTime);
                time.Text = getTimeString(dayTime);
            }
            else
            {
                timeWeek.Text = getTimeString(new TimeSpan(0));
                time.Text = getTimeString(new TimeSpan(0));
            }
        }

        private Boolean accessDatabase()
        {
            try
            {
                string connstring = string.Format(Properties.Resources.ResourceManager.GetString("ConnectionString"));
                connection = new MySqlConnection(connstring);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int checkWeek(DateTime monday)
        {
            connection.Open();

            int week_id = 0;
            string mondayMysql = monday.ToString(MySqlFormatter);

            MySqlParameter dateParam = new MySqlParameter("@week_start", MySqlDbType.Date);
            dateParam.Value = mondayMysql;

            String query = "select * from weeks where week_start = @week_start";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.Add(dateParam);

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();

                query = "insert into weeks(week_start, overall_time_worked) values(@week_start, @overall_time_worked)";
                cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add(dateParam);
                cmd.Parameters.Add("@overall_time_worked", MySqlDbType.LongBlob).Value = 0;

                Boolean result = cmd.ExecuteNonQuery() != 0;
                
                if (result)
                {
                    query = "SELECT LAST_INSERT_ID()";
                    cmd = new MySqlCommand(query, connection);

                    reader = cmd.ExecuteReader();

                    reader.Read();
                    week_id = reader.GetInt16(0);
                }
            }
            else
            {
                while (reader.Read())
                {
                    week_id = reader.GetInt16(0);
                    overall_week_id = week_id;

                    long sql_week_time = reader.GetInt64(2);
                    weekTime = new TimeSpan(sql_week_time * TicksPerMillisecond);
                }
            }

            if (!reader.IsClosed)
            {
                reader.Close();
            }

            connection.Close();

            return week_id;
        }

        private void checkDay(int week_id)
        {
            connection.Open();

            string todayMysql = today.ToString(MySqlFormatter);

            MySqlParameter dateParam = new MySqlParameter("@day_date", MySqlDbType.Date);
            dateParam.Value = todayMysql;

            String query = "select * from days where day_date = @day_date";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.Add(dateParam);

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();

                query = "insert into days(week_id, day_date, time_worked) values(@week_id, @day_date, @time_worked)";
                cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@week_id", MySqlDbType.Int32).Value = week_id;
                cmd.Parameters.Add(dateParam);
                cmd.Parameters.Add("@time_worked", MySqlDbType.LongBlob).Value = 0;

                Boolean result = cmd.ExecuteNonQuery() != 0;
                Console.WriteLine(result);
            }
            else
            {
                while (reader.Read()) 
                {
                    overall_day_id = reader.GetInt16(0);

                    long sql_day_time = reader.GetInt64(3);
                    dayTime = new TimeSpan(sql_day_time * TicksPerMillisecond);
                }
            }

            connection.Close();
        }

        private void checkPreviousDays(DateTime dateTime, int week_id)
        {
            connection.Open();

            string mondayMysql = dateTime.ToString(MySqlFormatter);

            MySqlParameter dateParam = new MySqlParameter("@day_date", MySqlDbType.Date);
            dateParam.Value = mondayMysql;

            String query = "select * from days where day_date >= @day_date";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.Add(dateParam);

            var reader = cmd.ExecuteReader();

            List<String> dataRead = new List<string>();

            while (reader.Read())
            {
                dataRead.Add(((DateTime)reader.GetMySqlDateTime(2)).ToString(MySqlFormatter));
            }

            reader.Close();

            Boolean dateIsToday = false;
            String dateToCheck;

            MySqlParameter weekParam = new MySqlParameter("@week_id", MySqlDbType.Int32);
            weekParam.Value = week_id;

            while (!dateIsToday)
            {
                dateToCheck = dateTime.ToString(MySqlFormatter);
                
                if (dateToCheck == today.ToString(MySqlFormatter))
                {
                    dateIsToday = true;
                }
                else if (!dataRead.Contains(dateToCheck))
                {
                    query = "insert into days(week_id, day_date, time_worked) values(@week_id, @day_date, @time_worked)";
                    cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.Add(weekParam);
                    cmd.Parameters.Add("@day_date", MySqlDbType.Date).Value = dateToCheck;
                    cmd.Parameters.Add("@time_worked", MySqlDbType.LongBlob).Value = 0;

                    Boolean result = cmd.ExecuteNonQuery() != 0;
                    Console.WriteLine(result);
                }

                dateTime = dateTime.AddDays(1);
            }

            connection.Close();
        }

        private void checkGraph()
        {
            connection.Open();

            string todayMysql = today.ToString(MySqlFormatter);

            MySqlParameter dateParam = new MySqlParameter("@day_date", MySqlDbType.Date);
            dateParam.Value = todayMysql;

            String query = "select * from days ORDER BY day_date DESC limit 7";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.Add(dateParam);

            var reader = cmd.ExecuteReader();

            List<graphData> graphData = new List<graphData>();

            while (reader.Read())
            {
                graphData data = new graphData();
                data.setDate((DateTime) reader.GetMySqlDateTime(2));
                data.setTime(new TimeSpan(reader.GetInt64(3) * TicksPerMillisecond));

                graphData.Add(data);
            }

            chart.Series.Clear();
            chart.ResetAutoValues();

            Series series = new Series("Data");

            int x = 0;

            foreach (graphData data in graphData)
            {

                series.Points.AddXY(data.getDate("ddd"), data.getTime().TotalHours);
                series.ChartType = SeriesChartType.Column;
                series.Points[x].Color = getChartColour(x);

                x++;
            }
            chart.Series.Add(series);
            chart.Update();

            connection.Close();
        }

        private void finshUp()
        {
            connection.Open();
            long elapsed = (long) stopwatch.Elapsed.TotalMilliseconds;

            String query = "update weeks set overall_time_worked = @overall_time_worked where week_id = @week_id";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.Add("@overall_time_worked", MySqlDbType.LongBlob).Value = elapsed + (long) weekTime.TotalMilliseconds;
            cmd.Parameters.Add("@week_id", MySqlDbType.Int32).Value = overall_week_id;

            Boolean weekResult = cmd.ExecuteNonQuery() != 0;

            query = "update days set time_worked = @time_worked where day_id = @day_id";
            cmd = new MySqlCommand(query, connection);
            cmd.Parameters.Add("@time_worked", MySqlDbType.LongBlob).Value = elapsed + (long) dayTime.TotalMilliseconds;
            cmd.Parameters.Add("@day_id", MySqlDbType.Int32).Value = overall_day_id;

            Boolean dayResult = cmd.ExecuteNonQuery() != 0;

            if (!weekResult || !dayResult)
            {
                Console.WriteLine("Whoops");
            }

            connection.Close();
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            if (timeTimer.Enabled)
            {
                btnWork.Text = "Start Work";
                work_end();
            }
            else
            {
                btnWork.Text = "Finish Work";
                work_start();
            }
        }

        private void work_start()
        {
            stopwatch.Start();
            timeTimer.Enabled = true;
        }

        private void work_end()
        {
            stopwatch.Stop();
            timeTimer.Enabled = false;
            finshUp();

            checkGraph();
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopwatch.Elapsed;

            time.Text = getTimeString(currentTime + dayTime);
            timeWeek.Text = getTimeString(currentTime + weekTime);
            timeCurrent.Text = getTimeString(currentTime);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            finshUp();
        }

        private String getTimeString(TimeSpan time)
        {
            return getTimeString(time.Hours, time.Minutes, time.Seconds, time.ToString("fff"));
        }

        private String getTimeString(long hours, long minutes, long seconds, String milliseconds)
        { 
            return hours + ":" + minutes + ":" + seconds + ":" + milliseconds;
        }

        private Color getChartColour(int x)
        {
            switch (x)
            {
                case 0:
                    return Color.DarkRed;
                case 1:
                    return Color.DarkBlue;
                case 2:
                    return Color.DarkGoldenrod;
                case 3:
                    return Color.DarkGreen;
                case 4:
                    return Color.DarkOrange;
                case 5:
                    return Color.DarkViolet;
                case 6:
                    return Color.DarkCyan;
                 default:
                    return Color.Blue;
            }
        }

        private class graphData
        {
            DateTime Date;
            TimeSpan Time;

            public void setDate(DateTime date)
            {
                this.Date = date;
            }

            public String getDate(String format)
            {
                return this.Date.ToString(format);
            }

            public void setTime(TimeSpan dateTime)
            {
                this.Time = dateTime;
            }

            public TimeSpan getTime()
            {
                return Time;
            }
        }

    }
}