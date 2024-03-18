import{_ as U,f as _,r as g,o as u,c,a,w as f,h as k,Z as j,b as h,F as S,g as x,d as y,v as L,t as V}from"./index-e5788531.js";const A={data(){return{department:null,hasServices:!1,usersList:[],users:[],subordinates:[],services:[],serviceSubordinateList:[],leader:null,team:null}},created(){this.getUsers(),this.getTeam()},methods:{updateDepartment(){var e=this,t;if(e.hasServices){e.services=e.services.map((r,i)=>(r.subordinates=e.serviceSubordinateList[i],r));for(var l=0;l<e.services.length;l++){var m=e.users.filter(r=>r.mailAddress==e.services[l].serviceLeader)[0];e.services[l].serviceLeader=m;for(var s=0;s<e.services[l].subordinates.length;s++){var d=e.users.filter(r=>r.mailAddress==e.services[l].subordinates[s].user)[0];e.services[l].subordinates[s].user=d}}t={name:e.department,services:e.services,hasServices:e.hasServices}}else e.subordinates=e.subordinates.map(r=>{var i=e.users.filter(o=>o.mailAddress==r.user);return{user:i[0],rank:r.rank}}),e.leader=e.users.filter(r=>r.mailAddress==e.leader)[0],t={name:e.department,subordinates:e.subordinates,hasServices:e.hasServices,leader:e.leader};console.log("this is the new department"),t._id=e.team._id,console.log(t);var v=this.authStore.getToken,n=new FormData;n.append("token",v),n.append("team",JSON.stringify(t)),_.post(e.globalUrl+"editTeam",n).then(r=>{r.data==!0&&e.$router.push("/systemAdmin")}).catch(r=>{e.$toast.warning(r)})},addSubordinate(){var e=this,t={user:null,rank:e.subordinates.length+2};e.subordinates.push(t)},deleteSubordinate(e,t){this.subordinates.splice(t,1)},addService(){var e=this,t={serviceName:null,subordinates:[],serviceLeader:null};e.serviceSubordinateList.push([]),e.services.push(t)},addServiceSubordinate(e,t){console.log("from inside service subordinate"+t);var l=this,m={user:null,rank:l.services[t].subordinates.length+2};l.serviceSubordinateList[t].push(m)},deleteServiceSubordinate(e,t,l){var m=this;m.serviceSubordinateList[l].splice(t,1)},deleteService(e,t){var l=this;l.services.splice(t,1)},getUsers(){var e=this,t=this.authStore.getToken,l=new FormData;l.append("token",t),_.post(e.globalUrl+"getUsers",l).then(m=>{e.users=m.data,e.usersList=e.users.map(s=>s.mailAddress)}).catch(m=>{e.$toast.warning(m)})},getTeam(){var e=this,t=this.authStore.getUser,l=this.authStore.getToken,m=this.$route.params.id,s=new FormData;s.append("user",JSON.stringify(t)),s.append("token",l),s.append("id",m),_.post(e.globalUrl+"getTeam",s).then(d=>{if(e.department=d.data.name,e.team=d.data,d.data.hasServices){var v=d.data.services;e.services=v.map(n=>{var r=n.serviceLeader.mailAddress;return n.serviceLeader=r,n}),e.serviceSubordinateList=v.map(n=>{var r=n.subordinates.map(i=>{var o=i.user;return i.user=o.mailAddress,i});return r}),e.hasServices=!0}else e.subordinates=d.data.subordinates.map(n=>{var r=n.user;return n.user=r.mailAddress,n}),e.leader=d.data.leader.mailAddress})}}},D={class:"h-full w-full",id:"app"},T={class:"h-20 bg-gray-100 w-full flex flex-row justify-between p-2 items-center"},N={class:"flex flex-row justify-center items-center"},F=a("label",{for:"hasServices"},"Has Different Services",-1),z={key:0,id:"body",class:"h-full w-full flex flex-col"},B={class:"flex flex-row items-center justify-start mt-10 ml-10"},E=a("label",{for:"",class:"mr-10 text-lg"},"Select Team Leader",-1),M={class:"w-1/3"},C={class:"flex flex-col h-auto rounded-md p-[50px] mt-10 justify-center items-center bg-gray-100"},J={class:"flex flex-row w-3/4 mr-10"},O=a("label",{for:"",class:""},"Select Subordinate",-1),R={class:"flex flex-row justify-center items-center"},H=a("label",{for:"",class:"mr-2"},"Select Rank",-1),Z=["onUpdate:modelValue"],q={key:1},G={class:"h-20 bg-gray-100 w-full flex flex-row justify-between p-2 items-center"},I=["onUpdate:modelValue"],K={class:"flex flex-row items-center justify-start w-full"},P=a("label",{for:"",class:"mr-10 text-lg"},"Select Team Leader",-1),Q={class:"w-1/3"},W={class:"flex flex-row w-3/4 mr-10"},X=a("label",{for:"",class:""},"Select Subordinate",-1),Y={class:"flex flex-row justify-center items-center"},$=a("label",{for:"",class:"mr-2"},"Select Rank",-1),ee=["onUpdate:modelValue"],se=["onClick"],te={class:"flex flex-row justify-center items-center"},re={class:"flex flex-row items-center w-full justify-end mr-10"};function ae(e,t,l,m,s,d){const v=g("vss"),n=g("font-awesome-icon");return u(),c("div",D,[a("div",T,[f(a("input",{type:"text","onUpdate:modelValue":t[0]||(t[0]=r=>s.department=r),placeholder:"Enter Department Name",class:"text-2xl p-4 ml-10 w-[500px] rounded-md border border-solid border-gray-600 h-12"},null,512),[[k,s.department]]),a("div",N,[F,f(a("input",{type:"checkbox","onUpdate:modelValue":t[1]||(t[1]=r=>s.hasServices=r),name:"hasServices",id:"hasServices",class:"h-9 w-16 border border-solid border-gray-600"},null,512),[[j,s.hasServices]])])]),s.hasServices?y("",!0):(u(),c("div",z,[a("div",B,[E,a("div",M,[h(v,{options:s.usersList,modelValue:s.leader,"onUpdate:modelValue":t[2]||(t[2]=r=>s.leader=r)},null,8,["options","modelValue"])])]),a("div",C,[(u(!0),c(S,null,x(s.subordinates,(r,i)=>(u(),c("div",{key:i,class:"flex flex-row w-full justify-center items-center mt-10"},[a("div",J,[O,h(v,{options:s.usersList,modelValue:s.subordinates[i].user,"onUpdate:modelValue":o=>s.subordinates[i].user=o},null,8,["options","modelValue","onUpdate:modelValue"])]),a("div",R,[H,f(a("select",{class:"h-12 w-12 border border-solid border-gray-200","onUpdate:modelValue":o=>s.subordinates[i].rank=o},[(u(!0),c(S,null,x(s.subordinates.length,(o,p)=>(u(),c("option",{key:p,class:"p-2"},V(p+2),1))),128))],8,Z),[[L,s.subordinates[i].rank]]),a("div",null,[h(n,{icon:"fa-solid fa-trash",size:"2x",class:"ml-10 text-rose-500",onClick:o=>d.deleteServiceSubordinate(o,i,e.serviceCounter)},null,8,["onClick"])])])]))),128)),a("div",{class:"h-auto w-auto my-10 bg-blue-500 text-2xl font-bold text-white p-5 rounded-md",onClick:t[3]||(t[3]=(...r)=>d.addSubordinate&&d.addSubordinate(...r))},"Add Subordinate")])])),s.hasServices?(u(),c("div",q,[(u(!0),c(S,null,x(s.services,(r,i)=>(u(),c("div",{class:"flex flex-col h-auto rounded-md p-[50px] mt-10 justify-center items-center bg-gray-100",key:i},[a("div",G,[f(a("input",{type:"text","onUpdate:modelValue":o=>s.services[i].serviceName=o,placeholder:"Enter Service Name",class:"text-2xl p-4 ml-10 w-[500px] rounded-md border border-solid border-gray-600 h-12"},null,8,I),[[k,s.services[i].serviceName]]),h(n,{icon:"fa-solid fa-trash",class:"text-red-500 hover:cursor-pointer",onClick:o=>d.deleteService(o,i),size:"3x"},null,8,["onClick"])]),a("div",K,[P,a("div",Q,[h(v,{options:s.usersList,modelValue:s.services[i].serviceLeader,"onUpdate:modelValue":o=>s.services[i].serviceLeader=o},null,8,["options","modelValue","onUpdate:modelValue"])])]),(u(!0),c(S,null,x(s.serviceSubordinateList[i],(o,p)=>(u(),c("div",{key:p,class:"flex flex-row w-full justify-center items-center mt-10"},[a("div",W,[X,h(v,{options:s.usersList,modelValue:s.serviceSubordinateList[i][p].user,"onUpdate:modelValue":b=>s.serviceSubordinateList[i][p].user=b},null,8,["options","modelValue","onUpdate:modelValue"])]),a("div",Y,[$,f(a("select",{class:"h-12 w-12 border border-solid border-gray-200","onUpdate:modelValue":b=>s.serviceSubordinateList[i][p].rank=b},[(u(!0),c(S,null,x(s.serviceSubordinateList[i].length,(b,w)=>(u(),c("option",{class:"p-2",key:w},V(w+2),1))),128))],8,ee),[[L,s.serviceSubordinateList[i][p].rank]]),a("div",null,[h(n,{icon:"fa-solid fa-trash",size:"2x",class:"ml-10 text-rose-500",onClick:b=>d.deleteServiceSubordinate(b,p,i)},null,8,["onClick"])])])]))),128)),a("div",{class:"h-auto w-auto mt-10 bg-blue-500 text-md font-bold text-white p-3 rounded-md",onClick:o=>d.addServiceSubordinate(o,i)},"Add Subordinate",8,se)]))),128)),a("div",te,[a("div",{class:"h-auto w-auto my-10 bg-emerald-500 text-2xl font-bold text-white p-5 rounded-md",onClick:t[4]||(t[4]=(...r)=>d.addService&&d.addService(...r))},"Add Service")])])):y("",!0),a("div",re,[a("div",{onClick:t[5]||(t[5]=(...r)=>d.updateDepartment&&d.updateDepartment(...r)),class:"h-auto w-auto p-6 mr-10 mb-10 rounded-md bg-blue-600 text-white font-bold text-4xl"},"Update Department")])])}const le=U(A,[["render",ae]]);export{le as default};
