create table member
(
	name 	 varchar(100)  not null,
    id	     varchar(100)  primary key,
    pw		 varchar(100)  not null,
    gender   varchar(10)   not null,
    email	 varchar(100)  unique,
    phone    varchar(20)   unique,
	birth	 date		   null,
    post	 varchar(10)   null,
    addr     varchar(100)  null,
    pt_code  varchar(3)	   not null,
    m_code   varchar(2)    null,
    jpo_code varchar(3)	   null
);

alter table member add constraint fk_1 foreign key(pt_code) references ptype(pt_code);
alter table member add constraint fk_2 foreign key(m_code) references major(m_code);
alter table member add constraint fk_3 foreign key(jpo_code) references jposition(jpo_code);