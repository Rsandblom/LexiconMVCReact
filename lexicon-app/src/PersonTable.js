import React from 'react'

const PersonTable = (props) => (
    <table className="table table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            {props.persons.length > 0 ? (
                props.persons.map((item) => (
                    <tr key={item.id}>
                        <td>{item.name}</td>
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

export default PersonTable