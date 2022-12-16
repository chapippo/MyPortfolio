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
		//����������� ����, � ������ ������ ���� �����ؼ� �� ���� ����
		ModelAndView mav = new ModelAndView();
		mav.addObject("data", list);	//view�� ������ ��
		mav.setViewName("/CovidD3chart");
		return mav;
	}
}




