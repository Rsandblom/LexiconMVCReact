import React, { useEffect, useState } from 'react'

const DetailsPersonForm = (props) => {

    const [person, setPerson] = useState(props.currentPerson);

    useEffect(
        () => {
            setPerson(props.currentPerson)
        },
        [props]
    )

    return (
        <form onSubmit={event => {
            event.preventDefault()

            props.deletePerson(person)
            //setPerson(initialFormState)
        }}>
            <div className="form-group">
                <label>Name</label>
                <input type="text" readOnly={true} name="name" value={person.name} className="form-control" />
            </div>
            <div className="form-group">
                <label>Phonenumber</label>
                <input type="text" readOnly={true} name="phoneNumber" value={person.phoneNumber} className="form-control" />
            </div>
            <div className="form-group">
                <label>City name</label>
                <input type="text" readOnly={true} name="cityName" value={person.cityName} className="form-control" />
            </div>
            <button className="btn btn-danger mt-2 mb-2 mr-sm-2">Delete user</button>
        </form>
    )
}

export default DetailsPersonForm