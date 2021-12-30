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
        }}>
            <div className="form-group">
                <label>Name</label>
                <input type="text" readOnly={true} name="name" value={person.name} className="form-control" />
            </div>
            <div className="form-group">
                <label>Phone-number</label>
                <input type="text" readOnly={true} name="phoneNumber" value={person.phoneNumber} className="form-control" />
            </div>
            <div className="form-group">
                <label>City name</label>
                <input type="text" readOnly={true} name="cityName" value={person.cityName} className="form-control" />
            </div>
            
            <div className="form-group">
                <label>Languages</label>
                {person.languages.length > 0 ? (
                    person.languages.map((item) => (
                        <div key={item.id} className="form-group">
                            <input type="text" readOnly={true} name="language" value={item.name} className="form-control mt-2" />
                        </div>
                    ))
                ) : (
                        <div>
                            <input type="text" readOnly={true} name="language" value={person.languages} className="form-control mt-2" />
                    </div>
                )}
            </div>
            <button className="btn btn-danger mt-2 mb-2 mr-sm-2">Delete user</button>
        </form>
    )
}

export default DetailsPersonForm