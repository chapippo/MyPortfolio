package com.myspring.notice;


public class NoticeDTO {
	private int bno;
	private String bname;
	private String titile;
	private String content;
	private String bdate;
	private int bHit;
	
	public int getBno() {return bno;}
	public void setBno(int bno) {this.bno = bno;}
	public String getBname() {return bname;}
	public void setBname(String bname) {this.bname = bname;}
	public String getTitile() {return titile;}
	public void setTitile(String titile) {this.titile = titile;}
	public String getContent() {return content;}
	public void setContent(String content) {this.content = content;}
	public String getBdate() {return bdate;}
	public void setBdate(String bdate) {this.bdate = bdate;}
	public int getbHit() {return bHit;}
	public void setbHit(int bHit) {this.bHit = bHit;}
	
}
