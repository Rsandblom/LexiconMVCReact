import React, { useEffect, useState } from 'react';
import './App.css';
import PersonTable from './PersonTable';
import AddPersonForm from './AddPersonForm';
import DetailsPersonForm from './DetailsPersonForm'


function App() {

    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState([]);
    const [cities, setCities] = useState([]);
    const initialFormState = { id: null, name: '', phoneNumber: '', cityName: '' };
    const [currentPerson, setCurrentPerson] = useState(initialFormState);

    const showDetails = (person) => {
        setCurrentPerson({ id: person.id, name: person.name, phoneNumber: person.phoneNumber, cityName: person.cityName });
    }

    const addPerson = (person) => {
        person.id = items.length + 1;
        alert(person.cityName + " " + person.name);
        setItems([...items, person]);


    }

    const deletePerson = (personDelete) => {
        setItems(items.filter((person) => person.id !== personDelete.id))
        setCurrentPerson(initialFormState);
    }

    // Note: the empty deps array [] means
    // this useEffect will run once
    // similar to componentDidMount()
    useEffect(() => {
        GetPersons();
    }, [])

    function GetPersons() {
        fetch("https://localhost:44389/react/getallpersons")
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setItems(result.reactPersonVMList);
                    setCities(result.citiesList);
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    }


    return (
        <div className="mt-3">
            
            <div className="container-fluid">
                <div className="row">
                    <div className="col-3">
                        <h2>Add person</h2>
                        <AddPersonForm addPerson={addPerson} cities={cities} />
                    </div>
                    <div className="col-3"></div>
                    <div className="col-3">
                        <h2>Person details</h2>
                        <DetailsPersonForm deletePerson={deletePerson} currentPerson={currentPerson}/>
                    </div>
                </div>
            </div>
            <div className="mt-4">
                <h2>Person list</h2>
                <div>
                    <PersonTable persons={items} showDetails={showDetails} />
                </div>
            </div>

        </div>

    )
}

export default App;
