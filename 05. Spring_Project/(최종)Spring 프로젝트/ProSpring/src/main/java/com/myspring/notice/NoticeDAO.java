package com.myspring.notice;



import java.util.List;
import java.util.Map;

import org.mybatis.spring.SqlSessionTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class NoticeDAO {
	@Autowired
	SqlSessionTemplate sqlSessionTemplate;
	
	public List<Map<String, Object>> notice_list(Map<String, Object> map){
		return this.sqlSessionTemplate.selectList("hospital.notice_list",map);
	}
	
	public Map<String, Object> notice_detail(Map<String, Object> map){
		return this.sqlSessionTemplate.selectOne("hospital.notice_detail", map);
	}
	
	public int notice_delete(String bno) {
		return this.sqlSessionTemplate.delete("hospital.notice_delete",bno);
	}
	
	public int notice_create(Map<String, Object> map) {
		return this.sqlSessionTemplate.insert("hospital.notice_create", map);
	}
	
	public void notice_read(Map<String, Object> map) {
		this.sqlSessionTemplate.update("hospital.notice_read",map);
	}
	
	public int notice_modify(Map<String, Object> map) {
		return this.sqlSessionTemplate.update("hospital.notice_modify", map);
	}
	
	public int notice_count(Map<String,Object> map) {
		return this.sqlSessionTemplate.selectOne("hospital.notice_count",map);
	}
}
