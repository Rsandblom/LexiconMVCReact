import React, { useEffect, useState } from 'react'

const PersonTable = (props) => {
    const [persons, setPersons] = useState(props.persons)

    useEffect(() => {
        setPersons(props.persons)
    }, [props])

    return (
        <table className="table table-striped">
            <thead>
                <tr>
                    <th>Id</th>
                    <th className="btn btn-outline-secondary mb-1" onClick={() => { props.sort() }}>Name</th>
                    <th>See details</th>
                </tr>
            </thead>
            <tbody>
                {persons.length > 0 ? (
                    persons.map((item) => (
                        <tr key={item.id}>
                            <td>{item.id}</td>
                            <td >{item.name}</td>
                            <td>
                                <button onClick={() => {props.showDetails(item)}} className="btn btn-primary">Details</button>
                            </td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={3}>No persons</td>
                    </tr>
                )}
            </tbody>
        </table>
    )
}

export default PersonTable