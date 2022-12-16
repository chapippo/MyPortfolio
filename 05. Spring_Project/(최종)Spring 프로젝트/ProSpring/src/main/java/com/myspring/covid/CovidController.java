package com.myspring.covid;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import org.springframework.web.servlet.ModelAndView;

@Controller
public class CovidController {
	
	@Autowired
	CovidService covidService;
	
	@RequestMapping(value="CovidD3Chart")
	public ModelAndView covidChart() {
								
		List<Map<String,Object>> list = 
				this.covidService.list();
		
		//ModelAndView 
		//어느페이지로 갈지, 어떤 데이터 보낼지 정보 저장해서 한 번에 보냄
		ModelAndView mav = new ModelAndView();
		mav.addObject("data", list);	//view에 전달할 값
		mav.setViewName("/CovidD3chart");
		return mav;
	}
}




