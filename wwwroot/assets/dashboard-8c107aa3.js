import{_ as h,f as p,r as u,o as m,c as g,a as e,j as r,b as l,t as f,n as k,d as v}from"./index-e5788531.js";const w={data(){return{assignedTickets:[],nonAssignedTickets:[],tickets:null,allTickets:[]}},created(){this.authStore.getUser,this.getTicketsForDepartmentHeads()},methods:{getTicketsForDepartmentHeads(){var s=this,t=this.authStore.getToken,d=this.authStore.getUser,c=new FormData;c.append("token",t),c.append("user",JSON.stringify(d)),p.post(s.globalUrl+"getTickets",c).then(n=>{s.tickets=n.data,s.assignedTickets=this.tickets.filter(o=>o.assigned==!0),s.nonAssignedTickets=this.tickets.filter(o=>o.assigned==!1&o.currentHandler.empName==d.empName),s.allTickets=this.tickets.filter(o=>o.ticketingHead.empName==d.empName)})}}},b={class:"flex flex-col justify-center items-center text-2xl mt-10 px-24 py-10",id:"app",style:{height:"auto",width:"auto"}},y={class:"flex flex-row justify-center items-center bg-red-200 w-full py-5"},T={class:"flex flex-row justify-end items-end w-full pr-10 text-2xl"},_={class:"flex flex-row justify-end items-end w-full pr-10 text-2xl"},j={class:"flex flex-row justify-end items-end w-full pr-10 text-2xl"},$={class:"flex flex-row justify-center items-center mt-10"};function N(s,t,d,c,n,o){const i=u("font-awesome-icon"),x=u("Loader");return m(),g("div",b,[e("div",y,[e("div",{class:"flex flex-col justify-center items-center hover:cursor-pointer bg-gradient-to-b from-red-500 to-red-400 w-72 text-center text-2xl rounded-sm text-white font-bold h-52 hover:scale-125 shadow-md shadow-black",onClick:t[0]||(t[0]=a=>this.$router.push("/ticketing/nonAssignedTickets")),id:"current_requests"},[r("Unassigned Tickets"),e("div",null,[l(i,{icon:"fa-solid fa-circle-exclamation",size:"4x",class:"mt-3"})]),e("div",T,f(n.nonAssignedTickets.length),1)]),e("div",{class:"ml-10 flex flex-col justify-center items-center hover:cursor-pointer bg-gradient-to-b from-blue-500 to-blue-400 w-72 text-center text-2xl rounded-sm text-white font-bold h-52 hover:scale-125 shadow-md shadow-black",onClick:t[1]||(t[1]=a=>this.$router.push("/ticketing/assignedTickets")),id:"my_requests"},[r("Assigned Tickets"),e("div",null,[l(i,{icon:"fa-solid fa-tasks",size:"4x",class:"mt-3"})]),e("div",_,f(n.assignedTickets.length),1)]),e("div",{class:"ml-10 flex flex-col justify-center items-center hover:cursor-pointer bg-gradient-to-b from-purple-500 to-purple-400 w-72 text-center text-2xl rounded-sm text-white font-bold h-52 hover:scale-125 shadow-md shadow-black",onClick:t[2]||(t[2]=a=>this.$router.push("/ticketing/allTickets")),id:"all_requests"},[r("All Tickets "),e("div",null,[l(i,{icon:"fa-solid fa-folder-open ",size:"4x",class:"mt-3"})]),e("div",j,f(n.allTickets.length),1)])]),e("div",$,[e("div",{class:"flex flex-col justify-center items-center hover:cursor-pointer bg-gradient-to-b from-lime-500 to-lime-400 w-72 text-center text-2xl text-white font-bold h-52 hover:scale-125 shadow-md shadow-black",onClick:t[3]||(t[3]=a=>this.$router.push("/admin/users")),id:"users"},[r(" Users "),e("div",null,[l(i,{icon:"fa-solid fa-user-astronaut",size:"4x",class:"mt-3"})])]),e("div",{class:"ml-10 flex flex-col justify-center items-center hover:cursor-pointer bg-gradient-to-b from-cyan-500 to-cyan-400 w-72 text-center text-2xl rounded-sm text-white font-bold h-52 hover:scale-125 shadow-md shadow-black",onClick:t[4]||(t[4]=a=>this.$router.push("/admin/groups")),id:"groups"},[r("Groups "),e("div",null,[l(i,{icon:"fa-solid fa-people-group",size:"4x",class:"mt-3"})])]),e("div",{class:"ml-10 flex flex-col justify-center items-center hover:cursor-pointer bg-gradient-to-b from-amber-500 to-amber-400 w-72 text-center text-2xl rounded-sm text-white font-bold h-52 hover:scale-125 shadow-md shadow-black",onClick:t[5]||(t[5]=a=>this.$router.push("/admin/files")),id:"files"},[r("All Uploaded Files"),e("div",null,[l(i,{icon:"fa-solid fa-folder-tree",size:"4x",class:"mt-3"})])])]),s.isLoading?(m(),k(x,{key:0})):v("",!0)])}const A=h(w,[["render",N]]);export{A as default};