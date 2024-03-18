import{B as he,C as y,D as A,E as v,G as _,H as N,I as Ie,J as Me,K as Oe,y as Ce,L as ae,M as xe,F as G,_ as Le,r as z,o as m,c as b,a as s,b as p,d as I,N as S,j as L,g as E,n as D}from"./index-e5788531.js";/**
 * Vue 3 Carousel 0.3.1
 * (c) 2023
 * @license MIT
 */const w={itemsToShow:1,itemsToScroll:1,modelValue:0,transition:300,autoplay:0,snapAlign:"center",wrapAround:!1,throttle:16,pauseAutoplayOnHover:!1,mouseDrag:!0,touchDrag:!0,dir:"ltr",breakpoints:void 0,i18n:{ariaNextSlide:"Navigate to next slide",ariaPreviousSlide:"Navigate to previous slide",ariaNavigateToSlide:"Navigate to slide {slideNumber}",ariaGallery:"Gallery",itemXofY:"Item {currentSlide} of {slidesCount}",iconArrowUp:"Arrow pointing upwards",iconArrowDown:"Arrow pointing downwards",iconArrowRight:"Arrow pointing to the right",iconArrowLeft:"Arrow pointing to the left"}},Ne={itemsToShow:{default:w.itemsToShow,type:Number},itemsToScroll:{default:w.itemsToScroll,type:Number},wrapAround:{default:w.wrapAround,type:Boolean},throttle:{default:w.throttle,type:Number},snapAlign:{default:w.snapAlign,validator(i){return["start","end","center","center-even","center-odd"].includes(i)}},transition:{default:w.transition,type:Number},breakpoints:{default:w.breakpoints,type:Object},autoplay:{default:w.autoplay,type:Number},pauseAutoplayOnHover:{default:w.pauseAutoplayOnHover,type:Boolean},modelValue:{default:void 0,type:Number},mouseDrag:{default:w.mouseDrag,type:Boolean},touchDrag:{default:w.touchDrag,type:Boolean},dir:{default:w.dir,validator(i){return["rtl","ltr"].includes(i)}},i18n:{default:w.i18n,type:Object},settings:{default(){return{}},type:Object}};function Ee({config:i,slidesCount:e}){const{snapAlign:l,wrapAround:d,itemsToShow:a=1}=i;if(d)return Math.max(e-1,0);let t;switch(l){case"start":t=e-a;break;case"end":t=e-1;break;case"center":case"center-odd":t=e-Math.ceil((a-.5)/2);break;case"center-even":t=e-Math.ceil(a/2);break;default:t=0;break}return Math.max(t,0)}function De({config:i,slidesCount:e}){const{wrapAround:l,snapAlign:d,itemsToShow:a=1}=i;let t=0;if(l||a>e)return t;switch(d){case"start":t=0;break;case"end":t=a-1;break;case"center":case"center-odd":t=Math.floor((a-1)/2);break;case"center-even":t=Math.floor((a-2)/2);break;default:t=0;break}return t}function ce({val:i,max:e,min:l}){return e<l?i:Math.min(Math.max(i,l),e)}function Be({config:i,currentSlide:e,slidesCount:l}){const{snapAlign:d,wrapAround:a,itemsToShow:t=1}=i;let h=e;switch(d){case"center":case"center-odd":h-=(t-1)/2;break;case"center-even":h-=(t-2)/2;break;case"end":h-=t-1;break}return a?h:ce({val:h,max:l-t,min:0})}function Pe(i){return i?i.reduce((e,l)=>{var d;return l.type===G?[...e,...Pe(l.children)]:((d=l.type)===null||d===void 0?void 0:d.name)==="CarouselSlide"?[...e,l]:e},[]):[]}function J({val:i,max:e,min:l=0}){return i>e?J({val:i-(e+1),max:e,min:l}):i<l?J({val:i+(e+1),max:e,min:l}):i}function Fe(i,e){let l;return e?function(...d){const a=this;l||(i.apply(a,d),l=!0,setTimeout(()=>l=!1,e))}:i}function Re(i,e){let l;return function(...d){l&&clearTimeout(l),l=setTimeout(()=>{i(...d),l=null},e)}}function Ge(i="",e={}){return Object.entries(e).reduce((l,[d,a])=>l.replace(`{${d}}`,String(a)),i)}var ze=he({name:"ARIA",setup(){const i=y("config",A(Object.assign({},w))),e=y("currentSlide",v(0)),l=y("slidesCount",v(0));return()=>_("div",{class:["carousel__liveregion","carousel__sr-only"],"aria-live":"polite","aria-atomic":"true"},Ge(i.i18n.itemXofY,{currentSlide:e.value+1,slidesCount:l.value}))}}),Ve=he({name:"Carousel",props:Ne,setup(i,{slots:e,emit:l,expose:d}){var a;const t=v(null),h=v([]),u=v(0),f=v(0),n=A(Object.assign({},w));let g=Object.assign({},w),o;const c=v((a=i.modelValue)!==null&&a!==void 0?a:0),M=v(0),V=v(0),P=v(0),B=v(0);let O,Q;N("config",n),N("slidesCount",f),N("currentSlide",c),N("maxSlide",P),N("minSlide",B),N("slideWidth",u);function Z(){o=Object.assign({},i.breakpoints),g=Object.assign(Object.assign(Object.assign({},g),i),{i18n:Object.assign(Object.assign({},g.i18n),i.i18n),breakpoints:void 0}),fe(g)}function H(){if(!o||!Object.keys(o).length)return;const r=Object.keys(o).map(k=>Number(k)).sort((k,x)=>+x-+k);let T=Object.assign({},g);r.some(k=>{const x=window.matchMedia(`(min-width: ${k}px)`).matches;return x&&(T=Object.assign(Object.assign({},T),o[k])),x}),fe(T)}function fe(r){Object.entries(r).forEach(([T,k])=>n[T]=k)}const pe=Re(()=>{H(),F()},16);function F(){if(!t.value)return;const r=t.value.getBoundingClientRect();u.value=r.width/n.itemsToShow}function $(){f.value<=0||(V.value=Math.ceil((f.value-1)/2),P.value=Ee({config:n,slidesCount:f.value}),B.value=De({config:n,slidesCount:f.value}),n.wrapAround||(c.value=ce({val:c.value,max:P.value,min:B.value})))}Ie(()=>{Me(()=>F()),setTimeout(()=>F(),1e3),H(),we(),window.addEventListener("resize",pe,{passive:!0}),l("init")}),Oe(()=>{Q&&clearTimeout(Q),O&&clearInterval(O),window.removeEventListener("resize",pe,{passive:!0})});let C=!1;const X={x:0,y:0},Y={x:0,y:0},W=A({x:0,y:0}),K=v(!1),ee=v(!1),We=()=>{K.value=!0},je=()=>{K.value=!1};function ve(r){["INPUT","TEXTAREA","SELECT"].includes(r.target.tagName)||(C=r.type==="touchstart",C||r.preventDefault(),!(!C&&r.button!==0||j.value)&&(X.x=C?r.touches[0].clientX:r.clientX,X.y=C?r.touches[0].clientY:r.clientY,document.addEventListener(C?"touchmove":"mousemove",ge,!0),document.addEventListener(C?"touchend":"mouseup",me,!0)))}const ge=Fe(r=>{ee.value=!0,Y.x=C?r.touches[0].clientX:r.clientX,Y.y=C?r.touches[0].clientY:r.clientY;const T=Y.x-X.x,k=Y.y-X.y;W.y=k,W.x=T},n.throttle);function me(){const r=n.dir==="rtl"?-1:1,T=Math.sign(W.x)*.4,k=Math.round(W.x/u.value+T)*r;if(k&&!C){const x=le=>{le.stopPropagation(),window.removeEventListener("click",x,!0)};window.addEventListener("click",x,!0)}U(c.value-k),W.x=0,W.y=0,ee.value=!1,document.removeEventListener(C?"touchmove":"mousemove",ge,!0),document.removeEventListener(C?"touchend":"mouseup",me,!0)}function we(){!n.autoplay||n.autoplay<=0||(O=setInterval(()=>{n.pauseAutoplayOnHover&&K.value||q()},n.autoplay))}function ke(){O&&(clearInterval(O),O=null),we()}const j=v(!1);function U(r){const T=n.wrapAround?r:ce({val:r,max:P.value,min:B.value});c.value===T||j.value||(l("slide-start",{slidingToIndex:r,currentSlideIndex:c.value,prevSlideIndex:M.value,slidesCount:f.value}),j.value=!0,M.value=c.value,c.value=T,Q=setTimeout(()=>{if(n.wrapAround){const k=J({val:T,max:P.value,min:0});k!==c.value&&(c.value=k,l("loop",{currentSlideIndex:c.value,slidingToIndex:r}))}l("update:modelValue",c.value),l("slide-end",{currentSlideIndex:c.value,prevSlideIndex:M.value,slidesCount:f.value}),j.value=!1,ke()},n.transition))}function q(){U(c.value+n.itemsToScroll)}function se(){U(c.value-n.itemsToScroll)}const Se={slideTo:U,next:q,prev:se};N("nav",Se),N("isSliding",j);const ye=Ce(()=>Be({config:n,currentSlide:c.value,slidesCount:f.value}));N("slidesToScroll",ye);const Ue=Ce(()=>{const r=n.dir==="rtl"?-1:1,T=ye.value*u.value*r;return{transform:`translateX(${W.x-T}px)`,transition:`${j.value?n.transition:0}ms`,margin:n.wrapAround?`0 -${f.value*u.value}px`:"",width:"100%"}});function Te(){Z(),H(),$(),F(),ke()}Object.keys(Ne).forEach(r=>{["modelValue"].includes(r)||ae(()=>i[r],Te)}),ae(()=>i.modelValue,r=>{r!==c.value&&U(Number(r))}),ae(f,$),l("before-init"),Z();const _e={config:n,slidesCount:f,slideWidth:u,next:q,prev:se,slideTo:U,currentSlide:c,maxSlide:P,minSlide:B,middleSlide:V};d({updateBreakpointsConfigs:H,updateSlidesData:$,updateSlideWidth:F,initDefaultConfigs:Z,restartCarousel:Te,slideTo:U,next:q,prev:se,nav:Se,data:_e});const te=e.default||e.slides,ie=e.addons,be=A(_e);return()=>{const r=Pe(te==null?void 0:te(be)),T=(ie==null?void 0:ie(be))||[];r.forEach((oe,re)=>oe.props.index=re);let k=r;if(n.wrapAround){const oe=r.map((ne,R)=>xe(ne,{index:-r.length+R,isClone:!0,key:`clone-before-${R}`})),re=r.map((ne,R)=>xe(ne,{index:r.length+R,isClone:!0,key:`clone-after-${R}`}));k=[...oe,...r,...re]}h.value=r,f.value=Math.max(r.length,1);const x=_("ol",{class:"carousel__track",style:Ue.value,onMousedownCapture:n.mouseDrag?ve:null,onTouchstartPassiveCapture:n.touchDrag?ve:null},k),le=_("div",{class:"carousel__viewport"},x);return _("section",{ref:t,class:{carousel:!0,"is-sliding":j.value,"is-dragging":ee.value,"is-hover":K.value,"carousel--rtl":n.dir==="rtl"},dir:n.dir,"aria-label":n.i18n.ariaGallery,tabindex:"0",onMouseenter:We,onMouseleave:je},[le,T,_(ze)])}}}),de;(function(i){i.arrowUp="arrowUp",i.arrowDown="arrowDown",i.arrowRight="arrowRight",i.arrowLeft="arrowLeft"})(de||(de={}));const He={arrowUp:"M7.41 15.41L12 10.83l4.59 4.58L18 14l-6-6-6 6z",arrowDown:"M7.41 8.59L12 13.17l4.59-4.58L18 10l-6 6-6-6 1.41-1.41z",arrowRight:"M8.59 16.59L13.17 12 8.59 7.41 10 6l6 6-6 6-1.41-1.41z",arrowLeft:"M15.41 16.59L10.83 12l4.58-4.59L14 6l-6 6 6 6 1.41-1.41z"};function Xe(i){return i in de}const ue=i=>{const e=y("config",A(Object.assign({},w))),l=String(i.name),d=`icon${l.charAt(0).toUpperCase()+l.slice(1)}`;if(!l||typeof l!="string"||!Xe(l))return;const a=He[l],t=_("path",{d:a}),h=e.i18n[d]||i.title||l,u=_("title",h);return _("svg",{class:"carousel__icon",viewBox:"0 0 24 24",role:"img","aria-label":h},[u,t])};ue.props={name:String,title:String};const Ye=(i,{slots:e,attrs:l})=>{const{next:d,prev:a}=e||{},t=y("config",A(Object.assign({},w))),h=y("maxSlide",v(1)),u=y("minSlide",v(1)),f=y("currentSlide",v(1)),n=y("nav",{}),{dir:g,wrapAround:o,i18n:c}=t,M=g==="rtl",V=_("button",{type:"button",class:["carousel__prev",!o&&f.value<=u.value&&"carousel__prev--disabled",l==null?void 0:l.class],"aria-label":c.ariaPreviousSlide,onClick:n.prev},(a==null?void 0:a())||_(ue,{name:M?"arrowRight":"arrowLeft"})),P=_("button",{type:"button",class:["carousel__next",!o&&f.value>=h.value&&"carousel__next--disabled",l==null?void 0:l.class],"aria-label":c.ariaNextSlide,onClick:n.next},(d==null?void 0:d())||_(ue,{name:M?"arrowLeft":"arrowRight"}));return[V,P]},Ke=()=>{const i=y("config",A(Object.assign({},w))),e=y("maxSlide",v(1)),l=y("minSlide",v(1)),d=y("currentSlide",v(1)),a=y("nav",{}),t=u=>J({val:d.value,max:e.value,min:0})===u,h=[];for(let u=l.value;u<e.value+1;u++){const f=_("button",{type:"button",class:{"carousel__pagination-button":!0,"carousel__pagination-button--active":t(u)},"aria-label":Ge(i.i18n.ariaNavigateToSlide,{slideNumber:u+1}),onClick:()=>a.slideTo(u)}),n=_("li",{class:"carousel__pagination-item",key:u},f);h.push(n)}return _("ol",{class:"carousel__pagination"},h)};var qe=he({name:"CarouselSlide",props:{index:{type:Number,default:1},isClone:{type:Boolean,default:!1}},setup(i,{slots:e}){const l=y("config",A(Object.assign({},w))),d=y("currentSlide",v(0)),a=y("slidesToScroll",v(0)),t=y("isSliding",v(!1)),h=()=>i.index===d.value,u=()=>i.index===d.value-1,f=()=>i.index===d.value+1,n=()=>{const g=Math.floor(a.value),o=Math.ceil(a.value+l.itemsToShow-1);return i.index>=g&&i.index<=o};return()=>{var g;return _("li",{style:{width:`${100/l.itemsToShow}%`},class:{carousel__slide:!0,"carousel__slide--clone":i.isClone,"carousel__slide--visible":n(),"carousel__slide--active":h(),"carousel__slide--prev":u(),"carousel__slide--next":f(),"carousel__slide--sliding":t.value},"aria-hidden":!n()},(g=e.default)===null||g===void 0?void 0:g.call(e))}}});const Ae="/assets/flowchart-e503f85a.png",Je={data(){return{blogs:[],showFlowChartCheck:!1,raiseTicketsSlidesCheck:!1,dealingWithTicketSlidesCheck:!1,powerUserSlidesCheck:!1,profileSlidesCheck:!1,knowledgeSlidesCheck:!1,accessSlidesCheck:!1,slides:["/src/assets/raiseTicket/Slide1.PNG","/src/assets/raiseTicket/Slide2.PNG","/src/assets/raiseTicket/Slide3.PNG","/src/assets/raiseTicket/Slide4.PNG","/src/assets/raiseTicket/Slide5.PNG","/src/assets/raiseTicket/Slide6.PNG","/src/assets/raiseTicket/Slide7.PNG","/src/assets/raiseTicket/Slide8.PNG","/src/assets/raiseTicket/Slide9.PNG","/src/assets/raiseTicket/Slide10.PNG","/src/assets/raiseTicket/Slide11.PNG","/src/assets/raiseTicket/Slide12.PNG","/src/assets/raiseTicket/Slide13.PNG","/src/assets/raiseTicket/Slide14.PNG","/src/assets/raiseTicket/Slide15.PNG","/src/assets/raiseTicket/Slide16.PNG"],dslides:["/src/assets/dealingWithTickets/Slide1.PNG","/src/assets/dealingWithTickets/Slide2.PNG","/src/assets/dealingWithTickets/Slide3.PNG","/src/assets/dealingWithTickets/Slide4.PNG","/src/assets/dealingWithTickets/Slide5.PNG","/src/assets/dealingWithTickets/Slide6.PNG","/src/assets/dealingWithTickets/Slide7.PNG","/src/assets/dealingWithTickets/Slide8.PNG","/src/assets/dealingWithTickets/Slide9.PNG","/src/assets/dealingWithTickets/Slide10.PNG","/src/assets/dealingWithTickets/Slide11.PNG","/src/assets/dealingWithTickets/Slide12.PNG","/src/assets/dealingWithTickets/Slide13.PNG","/src/assets/dealingWithTickets/Slide14.PNG","/src/assets/dealingWithTickets/Slide15.PNG","/src/assets/dealingWithTickets/Slide16.PNG","/src/assets/dealingWithTickets/Slide17.PNG","/src/assets/dealingWithTickets/Slide18.PNG","/src/assets/dealingWithTickets/Slide19.PNG","/src/assets/dealingWithTickets/Slide20.PNG","/src/assets/dealingWithTickets/Slide21.PNG"],prSlides:["/src/assets/profile/Slide1.PNG","/src/assets/profile/Slide2.PNG","/src/assets/profile/Slide3.PNG","/src/assets/profile/Slide4.PNG","/src/assets/profile/Slide5.PNG","/src/assets/profile/Slide7.PNG","/src/assets/profile/Slide8.PNG"],kSlides:["/src/assets/knowledge/Slide1.PNG","/src/assets/knowledge/Slide2.PNG","/src/assets/knowledge/Slide3.PNG","/src/assets/knowledge/Slide4.PNG","/src/assets/knowledge/Slide5.PNG","/src/assets/knowledge/Slide6.PNG"],aSlides:["/src/assets/access/Slide1.PNG","/src/assets/access/Slide2.PNG","/src/assets/access/Slide3.PNG","/src/assets/access/Slide4.PNG","/src/assets/access/Slide5.PNG","/src/assets/access/Slide6.PNG","/src/assets/access/Slide7.PNG","/src/assets/access/Slide8.PNG","/src/assets/access/Slide9.PNG"]}},components:{Carousel:Ve,Slide:qe,Pagination:Ke,Navigation:Ye},computed:{getHeight(){var i=document.getElementById("article"),e=i;return console.log("this is the height"),console.log(e),`${e}px`}},methods:{showFlowChart(){this.showFlowChartCheck==!1?this.showFlowChartCheck=!0:this.showFlowChartCheck=!1},raiseTicketSlides(){this.raiseTicketsSlidesCheck==!1?this.raiseTicketsSlidesCheck=!0:this.raiseTicketsSlidesCheck=!1},dealingWithTicketSlides(){this.dealingWithTicketSlidesCheck==!1?this.dealingWithTicketSlidesCheck=!0:this.dealingWithTicketSlidesCheck=!1},powerUserSlides(){this.powerUserSlidesCheck==!1?this.powerUserSlidesCheck=!0:this.powerUserSlidesCheck=!1},profileSlides(){this.profileSlidesCheck==!1?this.profileSlidesCheck=!0:this.profileSlidesCheck=!1},knowledgeSlides(){this.knowledgeSlidesCheck==!1?this.knowledgeSlidesCheck=!0:this.knowledgeSlidesCheck=!1},accessSlides(){this.accessSlidesCheck==!1?this.accessSlidesCheck=!0:this.accessSlidesCheck=!1},scrollToTop(){window.scrollTo({top:0,left:0,behavior:"smooth"})},scrollToSection(i){const e=this.$refs[i];if(e){const l=e.getBoundingClientRect(),d=60;window.scrollTo({top:window.scrollY+l.top-d,behavior:"smooth"})}}}},Qe={class:"flex flex-col h-full w-full justify-center items-center"},Ze=s("label",{class:"mt-2 group-hover:cursor-pointer"},"Top",-1),$e={class:"w-full h-full flex flex-row"},es={key:0,class:"fixed w-[100vw] h-full bg-white left-0 top-0 overflow-y-scroll p-10"},ss={class:"flex flex-row justify-end"},ts=s("img",{src:Ae,alt:"",srcset:""},null,-1),is={key:1,class:"fixed w-[100vw] h-[100vh] bg-white left-[0px] top-[0px] p-3"},ls={class:"flex flex-row justify-end"},os=["src"],rs={key:2,class:"fixed w-[100vw] h-[100vh] bg-white left-[0px] top-[0px] p-3"},ns={class:"flex flex-row justify-end"},as=["src"],cs={key:3,class:"fixed w-[100vw] h-[100vh] bg-white left-[0px] top-[0px] p-3"},ds={class:"flex flex-row justify-end"},us=["src"],hs={key:4,class:"fixed w-[100vw] h-[100vh] bg-white left-[0px] top-[0px] p-3"},fs={class:"flex flex-row justify-end"},ps=["src"],vs={key:5,class:"fixed w-[100vw] h-[100vh] bg-white left-[0px] top-[0px] p-3"},gs={class:"flex flex-row justify-end"},ms=["src"],ws={key:6,class:"fixed w-[100vw] h-[100vh] bg-white left-[0px] top-[0px] p-3"},ks={class:"flex flex-row justify-end"},Ss=["src"],ys={class:"w-[70vw] h-auto p-10 flex flex-col items-center",id:"article"},Ts={class:"p-3 lg:prose-lg w-full"},_s={class:"underline",ref:"intro"},bs=s("p",null,"This Help Desk system is designed to faciliate company service givers give services to other employees much more easily. It automates mundanes task, keeps records of all activites and alerts the users on various services related events. Hence, it relieves the concerned employees from the headache of having to keep track of things manually, and also acts as a proof of their work for top management. For top management, this system allows them to monitor and see trends related to services inside the company and thus take preemptive or proactive actions. ",-1),Cs={class:"underline",ref:"usage"},xs={class:"underline",id:"types",ref:"types"},Ns=s("p",null,"Before we get into the nitty gritty details of using this website, a primary thing that the user needs to be aware of are the user types available in this system. There are basically 6 different types of users in these system. They are: normal users, team leaders, support users, general power users, specific power users, admins and temporary leaders. These user types wil be explained in more detail in section 2.2. These user types will be assigned to each of the user of these sytem by the admin of the system(which is also another user type). The admin user type is assigned by the maintainers of the system. ",-1),Ps={class:"underline",ref:"differentTypes"},Gs={for:"",class:"underline",ref:"normal"},As=s("p",null,"They are the most common type of users and the majority of the users are expected to be of this type. They can raise new tickets (requests for help) and can see the status and progression of their own tickets.",-1),Ws={for:"",class:"underline",ref:"leader"},js=s("p",null,"For each support service their will be one assigned team leader. He/She can monitor the tickets raised for his service and determine which team member gets to resolve which ticket. He can monitor the acitivites of his team",-1),Us={for:"",class:"underline",ref:"support"},Is=s("p",null,"Each service will have support users headed by a team leader. Their job is to resolve tickets assigned to them by the team leader, and maintain communication with the ticket raiser regaridng the ticket.",-1),Ms={for:"",class:"underline",ref:"powerSpecific"},Os=s("p",null,"This is a special type of user who cannot raise a ticket or resolve tickets. Usually one person (probably the department head) will be assigned from each department head will be assigned this user type. They can monitor all the service activites under their department and can get analytics and insights from them. ",-1),Ls={for:"",class:"underline",ref:"powerGeneral"},Es=s("p",null,"They are just like power user specific except that instead of being confined to one particular department, they can monitor all the departments. This type is mostly assigned to top level management. ",-1),Ds={for:"",class:"underline",ref:"admin"},Bs=s("p",null,"The user type with the most priviledges. Not only can they monitor and get analytics of all the company wide services but they can also act as a proxy team leader or proxy support user for any of the service. They can also set up the different sevices and also who will lead these services and who will be in supporting roles. Also, they can assign user types to any user. These role is mostly assigned for one or two selected individuals in charge of maintaining the site. ",-1),Fs={class:"underline",ref:"workflow"},Rs=s("p",null,"In this section we will go through a basic description of the entire ticket handling cycle from the raising of a new ticket to its handing my the service support users and team leaders and finally to its closure.",-1),zs={class:"underline",ref:"flowchart"},Vs=s("p",null,"The following flow chart assumes that the ticket is raised for a service which has a service leader and two subordinates under him.",-1),Hs={class:"underline",ref:"access"},Xs={class:"underline",ref:"raise"},Ys={class:"underline",ref:"deal"},Ks={class:"underline",ref:"monitor"},qs={class:"underline",ref:"profile"},Js={class:"underline",ref:"knowledge"},Qs={class:"w-[25vw] h-auto"},Zs={class:"bg-gray-200 border border-solid border-black h-auto w-full"},$s={class:"p-10 md:prose-lg w-full"},et=s("h2",null,"Table of Contents",-1);function st(i,e,l,d,a,t){const h=z("font-awesome-icon"),u=z("slide"),f=z("navigation"),n=z("pagination"),g=z("carousel");return m(),b(G,null,[s("div",{class:"fixed bottom-10 right-16 h-auto w-auto group",onClick:e[0]||(e[0]=(...o)=>t.scrollToTop&&t.scrollToTop(...o))},[s("div",Qe,[p(h,{icon:"fa-solid fa-arrow-up",size:"3x",class:"group-hover:scale-150 group-hover:cursor-pointer"}),Ze])]),s("div",$e,[a.showFlowChartCheck==!0?(m(),b("div",es,[s("div",ss,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.showFlowChart},null,8,["onClick"])]),ts])):I("",!0),a.raiseTicketsSlidesCheck==!0?(m(),b("div",is,[s("div",ls,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.raiseTicketSlides},null,8,["onClick"])]),p(g,{"items-to-show":1},{addons:S(()=>[p(f),p(n)]),default:S(()=>[(m(!0),b(G,null,E(a.slides,(o,c)=>(m(),D(u,{key:c},{default:S(()=>[s("img",{src:o,alt:"",srcset:"",class:"w-[80vw] h-[90vh]"},null,8,os)]),_:2},1024))),128))]),_:1})])):I("",!0),a.dealingWithTicketSlidesCheck==!0?(m(),b("div",rs,[s("div",ns,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.dealingWithTicketSlides},null,8,["onClick"])]),p(g,{"items-to-show":1},{addons:S(()=>[p(f),p(n)]),default:S(()=>[(m(!0),b(G,null,E(a.dslides,(o,c)=>(m(),D(u,{key:c},{default:S(()=>[s("img",{src:o,alt:"",srcset:"",class:"w-[80vw] h-[90vh]"},null,8,as)]),_:2},1024))),128))]),_:1})])):I("",!0),a.powerUserSlidesCheck==!0?(m(),b("div",cs,[s("div",ds,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.powerUserSlides},null,8,["onClick"])]),p(g,{"items-to-show":1},{addons:S(()=>[p(f),p(n)]),default:S(()=>[(m(!0),b(G,null,E(t.powerUserSlides,(o,c)=>(m(),D(u,{key:c},{default:S(()=>[s("img",{src:o,alt:"",srcset:"",class:"w-[80vw] h-[90vh]"},null,8,us)]),_:2},1024))),128))]),_:1})])):I("",!0),a.profileSlidesCheck==!0?(m(),b("div",hs,[s("div",fs,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.profileSlides},null,8,["onClick"])]),p(g,{"items-to-show":1},{addons:S(()=>[p(f),p(n)]),default:S(()=>[(m(!0),b(G,null,E(a.prSlides,(o,c)=>(m(),D(u,{key:c},{default:S(()=>[s("img",{src:o,alt:"",srcset:"",class:"w-[80vw] h-[90vh]"},null,8,ps)]),_:2},1024))),128))]),_:1})])):I("",!0),a.knowledgeSlidesCheck==!0?(m(),b("div",vs,[s("div",gs,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.knowledgeSlides},null,8,["onClick"])]),p(g,{"items-to-show":1},{addons:S(()=>[p(f),p(n)]),default:S(()=>[(m(!0),b(G,null,E(a.kSlides,(o,c)=>(m(),D(u,{key:c},{default:S(()=>[s("img",{src:o,alt:"",srcset:"",class:"w-[80vw] h-[90vh]"},null,8,ms)]),_:2},1024))),128))]),_:1})])):I("",!0),a.accessSlidesCheck==!0?(m(),b("div",ws,[s("div",ks,[p(h,{icon:"fa-solid fa-multiply",size:"2x",class:"hover:cursor-pointer",onClick:t.accessSlides},null,8,["onClick"])]),p(g,{"items-to-show":1},{addons:S(()=>[p(f),p(n)]),default:S(()=>[(m(!0),b(G,null,E(a.aSlides,(o,c)=>(m(),D(u,{key:c},{default:S(()=>[s("img",{src:o,alt:"",srcset:"",class:"w-[80vw] h-[90vh]"},null,8,Ss)]),_:2},1024))),128))]),_:1})])):I("",!0),s("div",ys,[s("article",Ts,[s("h1",_s,"1 Introduction",512),bs,s("h1",Cs,"2 Usage",512),s("h2",xs,"2.1 User Types",512),Ns,s("h2",Ps,"2.2 Different User Types",512),s("ul",null,[s("li",null,[s("h3",Gs,"2.2.1 Normal Users:",512),As]),s("li",null,[s("h3",Ws,"2.2.2 Team leaders:",512),js]),s("li",null,[s("h3",Us,"2.2.3 Support Users:",512),Is]),s("li",null,[s("h3",Ms,"2.2.4 Power Users Specific:",512),Os]),s("li",null,[s("h3",Ls,"2.2.5 Power Users General:",512),Es]),s("li",null,[s("h3",Ds,"2.2.6 Admin:",512),Bs])]),s("h1",Fs,"3 Basic Workflow",512),Rs,s("h2",zs,"3.1 Workflow Flowchart (Click For Bigger View)",512),Vs,s("img",{src:Ae,alt:"",srcset:"",class:"hover:cursor-pointer",onClick:e[1]||(e[1]=(...o)=>t.showFlowChart&&t.showFlowChart(...o))}),s("h1",Hs,"4 Registering and Logging In(Out)",512),s("p",null,[L("To become eligible to use this system and to learn how to access the system follow the illustrated steps on the related slides. "),s("span",{class:"underline text-blue-500 hover:cursor-pointer",onClick:e[2]||(e[2]=(...o)=>t.accessSlides&&t.accessSlides(...o))},"Click here to launch the slide show:")]),s("h1",Xs,"5 Raising a Ticket",512),s("p",null,[L("To raise a new Ticket follow the illustrated steps on the related slide show. "),s("span",{class:"underline text-blue-500 hover:cursor-pointer",onClick:e[3]||(e[3]=(...o)=>t.raiseTicketSlides&&t.raiseTicketSlides(...o))},"Click here to launch the slide show:")]),s("h1",Ys,"6 Dealing with Tickets",512),s("p",null,[L("If you are the team leader of a service or a support user see the related slides to learn how to deal with tickets. "),s("span",{class:"underline text-blue-500 hover:cursor-pointer",onClick:e[4]||(e[4]=(...o)=>t.dealingWithTicketSlides&&t.dealingWithTicketSlides(...o))},"Click here to launch the slide show:")]),s("h1",Ks,"7 Monitoring Tickets (For Power Users)",512),s("p",null,[L("If you are a power user follow the related slides to learn how to monitor and get analytics data regarding the tickets. "),s("span",{class:"underline text-blue-500 hover:cursor-pointer",onClick:e[5]||(e[5]=(...o)=>t.powerUserSlides&&t.powerUserSlides(...o))},"Click here to launch the slide show:")]),s("h1",qs,"8 User Profile ",512),s("p",null,[L("Your user profile shows information regarding you. It also contains some information regarding you that you can edit. See the related slides for more information. "),s("span",{class:"underline text-blue-500 hover:cursor-pointer",onClick:e[6]||(e[6]=(...o)=>t.profileSlides&&t.profileSlides(...o))},"Click here to launch the slide show:")]),s("h1",Js,"9 Knowledge Base ",512),s("p",null,[L("The knowledge base is a repository of relevant knowledge and articles, that any of the users can use to aid them regarding any issue in the company. See the related slides for more information. "),s("span",{class:"underline text-blue-500 hover:cursor-pointer",onClick:e[7]||(e[7]=(...o)=>t.knowledgeSlides&&t.knowledgeSlides(...o))},"Click here to launch the slide show:")])])]),s("div",Qs,[s("div",Zs,[s("article",$s,[et,s("h3",{onClick:e[8]||(e[8]=o=>t.scrollToSection("intro")),class:"hover:cursor-pointer"},"1 Introduction"),s("h3",{onClick:e[9]||(e[9]=o=>t.scrollToSection("usage")),class:"hover:cursor-pointer"},"2 Usage"),s("h4",{onClick:e[10]||(e[10]=o=>t.scrollToSection("types")),class:"ml-5 hover:cursor-pointer"},"2.1 User Types"),s("h4",{onClick:e[11]||(e[11]=o=>t.scrollToSection("differentTypes")),class:"ml-5 hover:cursor-pointer"},"2.2 Different User Types"),s("h5",{onClick:e[12]||(e[12]=o=>t.scrollToSection("normal")),class:"ml-10 hover:cursor-pointer"},"2.2.1 Normal Users"),s("h5",{onClick:e[13]||(e[13]=o=>t.scrollToSection("leader")),class:"ml-10 hover:cursor-pointer"},"2.2.2 Team Leaders"),s("h5",{onClick:e[14]||(e[14]=o=>t.scrollToSection("support")),class:"ml-10 hover:cursor-pointer"},"2.2.3 Support Users"),s("h5",{onClick:e[15]||(e[15]=o=>t.scrollToSection("powerSpecific")),class:"ml-10 hover:cursor-pointer"},"2.2.4 Power Users Specific"),s("h5",{onClick:e[16]||(e[16]=o=>t.scrollToSection("powerGeneral")),class:"ml-10 hover:cursor-pointer"},"2.2.5 Power Users General"),s("h5",{onClick:e[17]||(e[17]=o=>t.scrollToSection("admin")),class:"ml-10 hover:cursor-pointer"},"2.2.6 Admin"),s("h3",{onClick:e[18]||(e[18]=o=>t.scrollToSection("workflow")),class:"hover:cursor-pointer"},"3 Basic Workflow"),s("h4",{onClick:e[19]||(e[19]=o=>t.scrollToSection("flowchart")),class:"ml-5 hover:cursor-pointer"},"3.1 Workflow Flowchart"),s("h3",{onClick:e[20]||(e[20]=o=>t.scrollToSection("access")),class:"hover:cursor-pointer"},"4 Registering and Logging In(Out)"),s("h3",{onClick:e[21]||(e[21]=o=>t.scrollToSection("raise")),class:"hover:cursor-pointer"},"5 Raising a Ticket"),s("h3",{onClick:e[22]||(e[22]=o=>t.scrollToSection("deal")),class:"hover:cursor-pointer"},"6 Dealing with Tickets"),s("h3",{onClick:e[23]||(e[23]=o=>t.scrollToSection("monitor")),class:"hover:cursor-pointer"},"7 Monitoring Tickets (For Power Users)"),s("h3",{onClick:e[24]||(e[24]=o=>t.scrollToSection("profile")),class:"hover:cursor-pointer"},"8 User Profile"),s("h3",{onClick:e[25]||(e[25]=o=>t.scrollToSection("knowledge")),class:"hover:cursor-pointer"},"9 Knowledge Base")])])])])],64)}const it=Le(Je,[["render",st]]);export{it as default};