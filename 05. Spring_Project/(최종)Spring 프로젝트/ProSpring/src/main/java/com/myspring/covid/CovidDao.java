package com.myspring.covid;

import java.util.List;
import java.util.Map;

import org.mybatis.spring.SqlSessionTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

//CovidDao�� Bean���� �����
//DB���� ���õ� Bean ��ü =
@Repository
public class CovidDao {
	
	//bean��ü�� �����ϴ� ��, ������ �ν��Ͻ��� ������ ��(�ڵ�)
	//new Ű���� ��� �ڵ����� ����� ��
	@Autowired
	SqlSessionTemplate sqlSessionTemplate;
	
	 //���� ���� Map<String,Object>�� ��ȯ��
	 public List<Map<String,Object>> selectList
	 (Map<String, Object> map) {  
		 return this.sqlSessionTemplate.selectList
				 ("covid.covid_list", map);
	 }


}
