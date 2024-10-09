;(function(root,factory){if(typeof define==='function'&&define.amd){define([],function(){return(factory());});}else if(typeof exports==='object'){module.exports=factory();}else{root.whatInput=factory();}}(this,function(){'use strict';var activeKeys=[];var body=document.body;var buffer=false;var currentInput=null;var formInputs=['input','select','textarea'];var formTyping=body.hasAttribute('data-whatinput-formtyping');var inputMap={'keydown':'keyboard','mousedown':'mouse','mouseenter':'mouse','touchstart':'touch','pointerdown':'pointer','MSPointerDown':'pointer'};var inputTypes=[];var keyMap={9:'tab',13:'enter',16:'shift',27:'esc',32:'space',37:'left',38:'up',39:'right',40:'down'};var pointerMap={2:'touch',3:'touch',4:'mouse'};var timer;function bufferInput(event){clearTimeout(timer);setInput(event);buffer=true;timer=setTimeout(function(){buffer=false;},1000);}
function immediateInput(event){if(!buffer)setInput(event);}
function setInput(event){var eventKey=key(event);var eventTarget=target(event);var value=inputMap[event.type];if(value==='pointer')value=pointerType(event);if(currentInput!==value){if(!formTyping&&currentInput&&value==='keyboard'&&keyMap[eventKey]!=='tab'&&formInputs.indexOf(eventTarget.nodeName.toLowerCase())>=0){}else{currentInput=value;body.setAttribute('data-whatinput',currentInput);if(inputTypes.indexOf(currentInput)===-1)inputTypes.push(currentInput);}}
if(value==='keyboard')logKeys(eventKey);}
function key(event){return(event.keyCode)?event.keyCode:event.which;}
function target(event){return event.target||event.srcElement;}
function pointerType(event){return(typeof event.pointerType==='number')?pointerMap[event.pointerType]:event.pointerType;}
function logKeys(eventKey){if(activeKeys.indexOf(keyMap[eventKey])===-1&&keyMap[eventKey])activeKeys.push(keyMap[eventKey]);}
function unLogKeys(event){var eventKey=key(event);var arrayPos=activeKeys.indexOf(keyMap[eventKey]);if(arrayPos!==-1)activeKeys.splice(arrayPos,1);}
function bindEvents(){var mouseEvent='mousedown';if(window.PointerEvent){mouseEvent='pointerdown';}else if(window.MSPointerEvent){mouseEvent='MSPointerDown';}
body.addEventListener(mouseEvent,immediateInput);body.addEventListener('mouseenter',immediateInput);if('ontouchstart'in window){body.addEventListener('touchstart',bufferInput);}
body.addEventListener('keydown',immediateInput);document.addEventListener('keyup',unLogKeys);}
if('addEventListener'in window&&Array.prototype.indexOf){bindEvents();}
return{ask:function(){return currentInput;},keys:function(){return activeKeys;},types:function(){return inputTypes;},set:setInput};}));