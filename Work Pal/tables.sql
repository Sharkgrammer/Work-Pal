create table weeks(
week_id int auto_increment,
week_start date not null,
overall_time_worked long,
primary key(week_id)
);

create table days(
day_id int auto_increment,
week_id int not null,
day_date date not null,
time_worked long,
primary key(day_id)
);