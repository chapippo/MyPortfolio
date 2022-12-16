create table notice
( 
	bno 	int 		 auto_increment primary key,
    bname 	varchar(30)  default '관리자',
    title 	varchar(100) default null,
    content varchar(500) default null,
    bdate	timestamp	 default current_timestamp,
    bHit	bigint 		 unsigned default 0
);