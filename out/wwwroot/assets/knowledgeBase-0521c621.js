import{_ as v,f as i,r as x,o as c,c as h,a as t,w as g,h as _,b as f,F as m,g as w,j as k,t as p}from"./index-e5788531.js";const y={data(){return{articles:[],searchTerm:null}},created(){var r=this,o=this.authStore.getUser,l=this.authStore.getToken,s=new FormData;s.append("user",o),s.append("token",l),i.post(r.globalUrl+"getAllBlogs",s).then(e=>{r.articles=e.data}).catch(e=>r.$toast.warning(e))},methods:{search(){console.log("searched");var r=this;this.authStore.getUser;var o=this.authStore.getToken,l=this.searchTerm,s=new FormData;s.append("token",o),s.append("search",l),i.post(r.globalUrl+"getFilteredBlogs",s).then(e=>{r.articles=e.data}).catch(e=>r.$toast.warning(e))},deleteArticle(r,e){console.log("delete called"),console.log(e);var l=this,s=this.authStore.getToken,e=e,n=new FormData;n.append("id",e),n.append("token",s),i.post(l.globalUrl+"deleteArticle",n).then(d=>{d.data==!0&&(l.articles=l.articles.filter(a=>a._id!=e))}).catch(d=>l.$toast.warning(d))},async copy(r,o){await navigator.clipboard.writeText(o)}}},T={class:"w-[90vw] h-[100vh] px-10 py-10"},j=t("div",{class:"flex flex-row justify-center items-center border-2 border-solid border-black p-4 rounded-md"},[t("label",{class:"text-black text-4xl font-bold"},"Knowledge Base")],-1),B={class:"flex flex-row justify-end w-full"},S={class:"flex flex-row mt-5 justify-center"},U={class:"flex flex-col w-full h-auto"},A=t("label",{class:"text-2xl font-bold"},"Articles:",-1),C={class:"flex flex-col w-3/4 h-auto"},F={class:"text-3xl pb-4 font-bold text-black mb-4 border-b-2 border-b-gray-500 flex flex-row justify-between"},$={class:"flex flex-row justify-end w-16 items-center"},D=["innerHTML"],N={class:"mt-2 flex flex-row justify-between items-center"},V={class:"border-2 border-solid border-black p-2"},L=["onClick"],M=t("div",null,null,-1);function H(r,o,l,s,e,n){const d=x("font-awesome-icon");return c(),h("div",T,[j,t("div",B,[t("div",S,[g(t("input",{"onUpdate:modelValue":o[0]||(o[0]=a=>e.searchTerm=a),type:"search",name:"",placeholder:"Search Article",id:"",class:"focus:outline-none text-bold text-lg border-b-2 border-t-2 border-l-2 border-solid border-l-gray-500 border-t-gray-500 border-b-gray-500 p-3 w-[200px]"},null,512),[[_,e.searchTerm]]),t("div",{class:"flex flex-col justify-center bg-gray-300 items-center p-3 border-t-2 border-r-2 border-b-2 border-solid border-r-gray-500 border-t-gray-500 border-b-gray-500 hover:cursor-pointer",onClick:o[1]||(o[1]=a=>n.search())},[f(d,{icon:"fa-solid fa-search"})])])]),t("div",U,[A,t("div",C,[(c(!0),h(m,null,w(e.articles,(a,u)=>(c(),h("div",{class:"w-full mb-5 p-3 bg-white h-auto flex flex-col border-2 border-solid border-gray-800",key:u},[t("div",F,[k(p(a.headline)+" ",1),t("div",$,[f(d,{icon:"fa-solid fa-copy",size:"lg",class:"hover:text-emerald-600 hover:scale-125 hover:cursor-pointer",onClick:b=>n.copy(b,this.frontUrl+"/blog/article/"+a._id)},null,8,["onClick"])])]),t("div",{class:"text-black h-[60px] truncate",innerHTML:a.content},null,8,D),t("div",N,[t("div",V,"Written By: "+p(a.authors.empName),1),t("div",{class:"border-2 border-solid border-black hover:cursor-pointer bg-blue-500 text-white font-bold p-2",onClick:b=>this.$router.push("/ticketing/blog/article/"+a._id)},"Read Article",8,L)])]))),128))]),M])])}const E=v(y,[["render",H]]);export{E as default};