const PhoneList = ({phones,title}) => {
    //const phones=props.phones;
    //const title = props.title;
    return (
        <div className="phone-list">
            <h2>{title}</h2>
            {phones.map((phone)=>(
            <div className="phone-preview" key={phone.id}>

                <h2>{phone.title}</h2>
                <p>written by {phone.author}</p>

            </div>
        
        ))}
        </div>
      );
}
 
export default PhoneList;