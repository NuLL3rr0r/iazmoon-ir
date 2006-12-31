var browser = navigator.userAgent;
//var wbsrvc = (window.location.href.indexOf('http://www.') != -1) ? 'http://www.iazmoon.ir/master.asmx' : 'http://iazmoon.ir/master.asmx';
var wbsrvc = 'http://localhost:1442/iazmoon/master.asmx';
var errSrvr = 'خطاي داخلي در سرور';
var ldr = '<img src="loading.gif" style="position: absolute; top: 11px; right: 11px;" /><br /><br /><br />';
function setInputStatus(str) {
	switch (str) {
		case "NotSetYet":
			document.getElementById('btnSend').disabled = true;
			document.getElementById('txtStudentNo').disabled = true;
			document.getElementById('txtStudentName').disabled = true;
			break;
		default:
			document.getElementById('btnSend').disabled = false;
			document.getElementById('txtStudentNo').disabled = false;
			document.getElementById('txtStudentName').disabled = false;
			break;
	}
}
function sendStudent() {
	var num = document.frmGetResults.cmbExamName.selectedIndex;
	var eT = document.frmGetResults.cmbExamName.options[num].value;
	var sNo = new String(document.getElementById('txtStudentNo').value);
	var sNm = new String(document.getElementById('txtStudentName').value);
	var obj = document.getElementById('divErrVerify');
	if (sNo != '' && sNm != '') {
		document.getElementById('divMain').innerHTML = ldr;
		talkingServer('<examType>' + eT + '</examType><studentNo>' + sNo + '</studentNo><studentName>' + sNm + '</studentName>', 'fetchGetStudentResult', 'POST');
	}
	else if (sNo == '') {
		obj.innerHTML = 'لطفا كد داوطلبي را وارد نمائيد';
		obj.style.visibility = 'visible';
	}
	else if (sNm == '') {
		obj.innerHTML = 'لطفا نام و نام خانوادگي را وارد نمائيد';
		obj.style.visibility = 'visible';
	}
}
function filterTalking(msg, tag) {
	if (msg != 'Internal Server Error')	{
		var pos1 = msg.indexOf('<' + tag + '>');
		var pos2 = msg.indexOf('</' + tag + '>');
		var tagLen = tag.length + 2;
		return msg.substr(pos1 + tagLen, pos2 - pos1 - tagLen);
	}
	else
		return errSrvr;
}
function detectChar(ch) {
	switch (ch) {
		case "&lt;":
			return '<';
			break;
		case "&gt;":
			return '>';
			break;
		case "&amp;nbsp;":
			return '&nbsp;';
			break;
		default:
			break;
	}
}
function correctTags(str, ch) {
	parts = str.split(ch);
	var clnd = parts.join(detectChar(ch));
	return clnd;
}
function correctPageTags(str, tag) {
	str = filterTalking(str, tag)
	str = correctTags(str, '&lt;');
	str = correctTags(str, '&gt;');
	str = correctTags(str, '&amp;nbsp;');
	return str;
}
function getXMLHTTPRequest() {
	try {
		req = new XMLHttpRequest();
	}
	catch(e) {
		try {
			req = new ActiveXObject("Msxml2.XMLHTTP");
		}
		catch (e) {
			try {
				req = new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch (E) {
				req = false;
			}
		}
	}
	return req;
}
function resultOnTalkingServer(code, msg, op) {
	var where = new String();
	switch (op) {
		case "fetchGetResultsForm":
			where = 'divMain';
			break;
		case "fetchGetStudentResult":
			where = 'divMain';
			break;
		default:
			break;
	}
	var err = (msg != 'Internal Server Error') ? false : true;
	msg = msg.replace('{PlaceHolder}', fixRecommends());
	var obj = document.getElementById(where);
	if (!err)
		obj.innerHTML = correctPageTags(msg, op + 'Result');
	else
		obj.innerHTML = errSrvr;
}
function talkingServer(param, op, method) {
	var http = getXMLHTTPRequest();
	http.open(method, wbsrvc, true);
	http.onreadystatechange=function() {
		if (http.readyState==4) {
			if(http.status==200) {
				resultOnTalkingServer(0, http.responseText, op);
				return;
			}
			else {
				resultOnTalkingServer(1, http.statusText, op);
				return;
			}
		}
	}
	http.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
	var sendSOAP = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><' + op + ' xmlns="' + 'http://tempuri.org/' + '">' + param + '</' + op + '></soap:Body></soap:Envelope>';
	http.send(sendSOAP);
}
function doPrint() {
	document.getElementById('prn').style.visibility = 'hidden';
	print();
}
function notFound() {
	document.getElementById('divMain').innerHTML = ldr;
	talkingServer('', 'fetchGetResultsForm', 'POST');
}
function clickIE4() {
	if (event.button==2)
		return false;
}
function clickNS4(e) {
	if (document.layers||document.getElementById&&!document.all)
		if (e.which==2||e.which==3)
			return false;
}
if (document.layers) {
	document.captureEvents(Event.MOUSEDOWN);
	document.onmousedown=clickNS4;
}
else if (document.all&&!document.getElementById)
	document.onmousedown=clickIE4;
document.oncontextmenu=new Function("return false");
top.window.moveTo(0,0);
if (document.all) {
	top.window.resizeTo(screen.availWidth,screen.availHeight);
}
else if (document.layers||document.getElementById) {
	if (top.window.outerHeight<screen.availHeight||top.window.outerWidth<screen.availWidth){
		top.window.outerHeight = screen.availHeight;
		top.window.outerWidth = screen.availWidth;
	}
}
function fixRecommends() {
	if (browser.indexOf('Gecko') == -1)
		return '<br />Tips: For best performance, we recommends <a href="http://www.getfirefox.com/" target="_blank">Firefox</a><br />';
	return '';
}