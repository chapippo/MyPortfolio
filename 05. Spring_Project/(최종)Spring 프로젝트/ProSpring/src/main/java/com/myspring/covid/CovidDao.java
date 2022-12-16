package com.myspring.covid;

import java.util.List;
import java.util.Map;

import org.mybatis.spring.SqlSessionTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

//CovidDao를 Bean으로 등록함
//DB연결 관련된 Bean 객체 =
@Repository
public class CovidDao {
	
	//bean객체를 생성하는 데, 적절한 인스턴스를 생성해 줌(자동)
	//new 키워드 없어도 자동으로 만들어 줌
	@Autowired
	SqlSessionTemplate sqlSessionTemplate;
	
	 //여러 개의 Map<String,Object>을 반환함
	 public List<Map<String,Object>> selectList
	 (Map<String, Object> map) {  
		 return this.sqlSessionTemplate.selectList
				 ("covid.covid_list", map);
	 }


}
