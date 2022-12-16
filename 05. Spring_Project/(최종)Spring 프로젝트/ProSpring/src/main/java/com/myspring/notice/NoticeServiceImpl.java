package com.myspring.notice;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class NoticeServiceImpl implements NoticeService{
	@Autowired
	NoticeDAO dao;

	@Override
	public List<Map<String, Object>> notice_list(Map<String, Object> map) {
		return this.dao.notice_list(map);
	}

	@Override
	public Map<String, Object> notice_detail(Map<String, Object> map) {
		return this.dao.notice_detail(map);
	}

	@Override
	public boolean notice_delete(String bno) {
		int affectRowCount = this.dao.notice_delete(bno);
		return affectRowCount == 1;
	}

	@Override
	public String notice_create(Map<String, Object> map) {
		int affectRowCount = this.dao.notice_create(map);
		if(affectRowCount == 1) {
			return map.get("bno").toString();
		}
		return null;
	}

	@Override
	public void notice_read(Map<String, Object> map) {
		this.dao.notice_read(map);
		
	}

	@Override
	public boolean notice_modify(Map<String, Object> map) {
		int affectRowCount = this.dao.notice_modify(map);
		return affectRowCount == 1;
	}

	@Override
	public int notice_count(Map<String, Object> map) {
		return this.dao.notice_count(map);
	}
	
	
	
}
