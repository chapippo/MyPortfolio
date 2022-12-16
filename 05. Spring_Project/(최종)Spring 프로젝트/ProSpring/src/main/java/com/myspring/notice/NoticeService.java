package com.myspring.notice;

import java.util.List;
import java.util.Map;



public interface NoticeService {

	List<Map<String, Object>> notice_list(Map<String, Object> map);

	Map<String, Object> notice_detail(Map<String, Object> map);
	
	boolean notice_delete(String bno);
	
	String notice_create(Map<String, Object> map);
	
	void notice_read(Map<String, Object> map);
	
	boolean notice_modify(Map<String, Object> map);
	
	int notice_count(Map<String,Object> map);
}
