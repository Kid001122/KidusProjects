import { useState,useEffect} from "react"
import PhoneList from "./phoneList";
import useFetch from "./useFetch";

const Home= () => {
    const {data:phones,isPending,error}=useFetch('http://localhost:8000/phones');
  
    
  
    return (  
        <div className="Home">
            {error && <div>{error}</div>}
            {isPending && <div>Loading...</div>}
       {phones && <PhoneList phones={phones} title="All phone books"/>}
        </div>
   );
}
 
export default Home;