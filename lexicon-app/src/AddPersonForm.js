import React, { useState } from 'react'

const AddPersonForm = (props) => {

    const initialFormState = { id: null, name: '', phoneNumber: '', cityName: '1'};
    const [person, setPerson] = useState(initialFormState);
    const [optionValue, setOptionValue] = useState(1);
    const [errorMsg, setErrorMsg] = useState('');

    const handleSelect = (e) => {
        console.log(e.target.value);
        setOptionValue(e.target.value);

        setPerson({ ...person, cityName: e.target.value })
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setPerson({ ...person, [name]: value });
        setErrorMsg('');
    }

    return (
        <form onSubmit={event => {
            event.preventDefault()
            if (!person.name || !person.phoneNumber) {
                setErrorMsg("Name and phone-number cannot be empty!!")
                return;
            }

            props.addPerson(person)
            setPerson(initialFormState)
            setOptionValue(1);
        }}>
            <span className="text-danger">{errorMsg}</span>
            <div className="form-group">
                <label>Name</label>
                <input type="text" name="name" value={person.name} onChange={handleInputChange} className="form-control"/>
            </div>
            <div className="form-group">
                <label>Phone-number</label>
                <input type="text" name="phoneNumber" value={person.phoneNumber} onChange={handleInputChange} className="form-control" />
            </div>
            
            <div className="form-group">
                <label className="mb-2 mr-2">Pick City </label>
                <div className="mb-3">
                    <select className="btn btn-primary dropdown-toggle" value={optionValue} onChange={handleSelect}>
                        {props.cities.map(city => (
                            <option key={city.id} value={city.id} >{ city.name }</option>
                        ))}
                </select>
                </div>
            </div>
            

            <button className="btn btn-primary mb-2 mr-sm-2">Add new user</button>
        </form>
    )
}

export default AddPersonForm