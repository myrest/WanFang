function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function JustSoPicWindow(imageName,imageWidth,imageHeight,alt,bgcolor,hugger,hugMargin) {
// by E Michael Brandt of ValleyWebDesigns.com - Please leave these comments intact.
// version 3.0.4  

    if (bgcolor=="") {
        bgcolor="#999999";
    }
    var adj=10
    var w = screen.width;
    var h = screen.height;
    var byFactor=1;

    if(w<740){
      var lift=0.90;
    }
    if(w>=740 & w<835){
      var lift=0.91;
    }
    if(w>=835){
      var lift=0.93;
    }
    if (imageWidth>w){	
      byFactor = w / imageWidth;			
      imageWidth = w;
      imageHeight = imageHeight * byFactor;
    }
    if (imageHeight>h-adj){
      byFactor = h / imageHeight;
      imageWidth = (imageWidth * byFactor);
      imageHeight = h; 
    }
       
    var scrWidth = w-adj;
    var scrHeight = (h*lift)-adj;

    if (imageHeight>scrHeight){
      imageHeight=imageHeight*lift;
      imageWidth=imageWidth*lift;
    }

    var posLeft=0;
    var posTop=0;

    if (hugger == "hug image"){
      if (hugMargin == ""){
        hugMargin = 0;
      }
      var scrHeightTemp = imageHeight - 0 + 2*hugMargin;
      if (scrHeightTemp < scrHeight) {
        scrHeight = scrHeightTemp;
      } 
      var scrWidthTemp = imageWidth - 0 + 2*hugMargin;
      if (scrWidthTemp < scrWidth) {
        scrWidth = scrWidthTemp;
      }
      
      if (scrHeight<100){scrHeight=100;}
      if (scrWidth<100){scrWidth=100;}

      posTop =  ((h-(scrHeight/lift)-adj)/2);
      posLeft = ((w-(scrWidth)-adj)/2);
    }

    if (imageHeight > (h*lift)-adj || imageWidth > w-adj){
        imageHeight=imageHeight-adj;
        imageWidth=imageWidth-adj;
    }
    posTop = parseInt(posTop);
    posLeft = parseInt(posLeft);		
    scrWidth = parseInt(scrWidth); 
    scrHeight = parseInt(scrHeight);
    
    var agt=navigator.userAgent.toLowerCase();
    if (agt.indexOf("opera") != -1){
      var args= new Array();
      args[0]='parent';
      args[1]=imageName;
      var i ; document.MM_returnValue = false;
      for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
    } else {
    newWindow = window.open("vwd_justso.htm","newWindow","width="+scrWidth+",height="+scrHeight+",left="+posLeft+",top="+posTop+",resizable=yes");
    newWindow.document.open();
    newWindow.document.write('<html><title>'+alt+'</title><body leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" bgcolor='+bgcolor+' onBlur="self.close()" onClick="self.close()">');  
    newWindow.document.write('<table width='+imageWidth+' border="0" cellspacing="0" cellpadding="0" align="center" height='+scrHeight+' ><tr><td>');
    newWindow.document.write('<img src="'+imageName+'" width='+imageWidth+' height='+imageHeight+' alt="Click screen to close" >'); 
    newWindow.document.write('</td></tr></table></body></html>');
    newWindow.document.close();
    newWindow.focus();
    }
}

function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}

function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

<!-- 
function view_ans(num) { 
if(document.getElementById("ans" + num).style.display == "none") { 
document.getElementById("ans" + num).style.display = "block"; 
} else if(document.getElementById("ans" + num).style.display == "block") { 
document.getElementById("ans" + num).style.display = "none"; 
} 
} 

function close_ans(num) {
if(document.getElementById("ans" + num).style.display == "block")
{
document.getElementById("ans" + num).style.display = "none";
}
}
//--> 



function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function swap(imgIndex) {
document['imgMain'].src = aryImages[imgIndex];
}

function MM_popupMsg(msg) { //v1.0
alert(msg);
}
