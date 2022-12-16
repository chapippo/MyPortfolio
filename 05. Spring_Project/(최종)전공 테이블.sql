create table major
(
	m_code  varchar(2)  primary key,
    name 	varchar(20) unique
);

insert into major values('','');
insert into major values('01','내과');
insert into major values('05','정형외과');
insert into major values('12','안과');
insert into major values('13','이비인후과');
insert into major values('49','치과');
