package com.myspring.mypro;

import java.util.List;
import java.util.Map;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;


import com.myspring.notice.NoticeServiceImpl;



@Controller
public class NoticeController {
	@Autowired
	NoticeServiceImpl service;
	
	// 공지사항 목록화면 요청
	@RequestMapping(value = "/list.board", method = RequestMethod.GET)
	public ModelAndView notice_list(@RequestParam Map<String, Object> map, @RequestParam(value="nowPage", required=false) String nowPage) {
		double CNT = 5.0; //한 번에 보여지는 페이지 의미(밑에 숫자)
		int LIMITCOUNT = (int)CNT;
		if(nowPage!=null) {
			int now = Integer.parseInt(nowPage);
			int skipCount=0;
			if(now>1)
				skipCount = (now-1)*LIMITCOUNT;
			map.put("skipCount", skipCount);
		} else {
			map.put("skipCount",0);
		}
		
		List<Map<String, Object>> noticeList = this.service.notice_list(map);
		ModelAndView mav = new ModelAndView();
		mav.addObject("data", noticeList);
		int totalCount = (int)Math.ceil(this.service.notice_count(map)/CNT);
		mav.addObject("totalCount", totalCount);//맨 끝 페이지 정보
		
		int nowPos = nowPage==null?1:Integer.parseInt(nowPage);
		if(nowPos<=0)
			nowPos=1;
		mav.addObject("nowPage",nowPos);
		
		int endPage = (int)(Math.ceil(nowPos/CNT)*(LIMITCOUNT));
		int startPage = 0;
		if(endPage>totalCount) { //끝 부분
			startPage = endPage-(LIMITCOUNT)+1;
			endPage=totalCount;
		} else {
			startPage = endPage-(LIMITCOUNT)+1;
		}
		if(startPage<=0)
			startPage=1;
		mav.addObject("startPage", startPage);
		mav.addObject("endPage", endPage);
		
		//검색시 파라메터 더 추가함
		//검색 아무 것도 입력 안 하면 원래의 목록보기 처럼 동작
		if(map.containsKey("keyword"))
			mav.addObject("keyword", map.get("keyword"));
		
		mav.setViewName("/notice/list");
		return mav;
	}
		
	// 공지 내용 요청
	@RequestMapping(value = "/notice_detail", method = RequestMethod.GET)
	public ModelAndView noticeDetail(@RequestParam Map<String, Object> map) {
		Map<String, Object> detailMap = this.service.notice_detail(map);
		this.service.notice_read(detailMap);
		ModelAndView mav = new ModelAndView();
		mav.addObject("data", detailMap);
		mav.setViewName("/notice/detail");
		return mav;
	}
		
	
	// 공지 삭제
	@RequestMapping(value = "/notice_delete", method = RequestMethod.POST)
	public ModelAndView noticeDelete(@RequestParam Map<String, Object> map) {
		ModelAndView mav = new ModelAndView();
		String bno = map.get("bno").toString();
		boolean isDeleteSuccess = this.service.notice_delete(bno);
		if(isDeleteSuccess) {
			mav.setViewName("redirect:/list.board");
		} else {
			mav.setViewName("redirect:/notice_detail?bno="+bno);
		}
		return mav;
	}
	
	// 새로운 공지 작성
	@RequestMapping(value = "/notice_write", method = RequestMethod.GET)
	public ModelAndView noticeWrite() {
		ModelAndView mav = new ModelAndView();
		mav.setViewName("/notice/new");
		return mav;
	}
	
	// 새로운 공지 저장 요청
	@RequestMapping(value = "/notice_create", method = RequestMethod.POST)
	public ModelAndView noticeCreate(@RequestParam Map<String, Object> map) {
		ModelAndView mav = new ModelAndView();
		String bno = this.service.notice_create(map);
		if(bno == null) {
			mav.setViewName("redirect:/notice_create");
		} else {
			mav.setViewName("redirect:/list.board");
		}
		return mav;
	}
	
	// 공지 수정 요청
	@RequestMapping(value = "/notice_modify", method = RequestMethod.GET)
	public ModelAndView noticeModify(@RequestParam Map<String, Object> map) {
		ModelAndView mav = new ModelAndView();
		Map<String, Object> detailMap = this.service.notice_detail(map);
		mav.addObject("data", detailMap);
		mav.setViewName("/notice/modify");
		return mav;
	}
	
	// 공지 수정 후
	@RequestMapping(value = "/notice_modify", method = RequestMethod.POST)
	public ModelAndView noticeModifyPost(@RequestParam Map<String, Object> map) {
		ModelAndView mav = new ModelAndView();
		
		boolean isUpdateSuccess = this.service.notice_modify(map);
		if(isUpdateSuccess) {
			mav.setViewName("redirect:/list.board");
		} else {
			String bno = map.get("bno").toString();
			mav.setViewName("redirect:/notice_detail?bno="+bno);
		}
		return mav;
	}
	
}
