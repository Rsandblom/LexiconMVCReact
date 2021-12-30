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
    const initialFormState = { id: null, name: '', phoneNumber: '', cityName: '', languages: [] };
    const [currentPerson, setCurrentPerson] = useState(initialFormState);
    const [reRender, setReRender] = useState(0);
    const [sortOrder, setSortOrder] = useState("asc");

    const showDetails = (person) => {
        setCurrentPerson({ id: person.id, name: person.name, phoneNumber: person.phoneNumber, cityName: person.cityName, languages: person.languages});
    }

    function SortPersonList() {
        if (sortOrder === "asc") {
            items.sort((first, second) => {
                return first.name > second.name ? 1 : -1;
            });
            setSortOrder("dsc");
        }
        else {
            items.sort((first, second) => {
                return first.name > second.name ? -1 : 1;
            });
            setSortOrder("asc");
        }
    }

    useEffect(() => {
        GetPersons();
    }, [reRender])

    function GetPersons() {
        fetch("https://localhost:44389/react/getallpersons")
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setItems(result.reactPersonVMList);
                    console.log(items);
                    setCities(result.citiesList);
                },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    }

    const addPerson = (person) => {
        PostPerson(person);
        setReRender(reRender + 1);
    }

    function PostPerson(person) {
        fetch("https://localhost:44389/react/create", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: person.name, phoneNumber: person.phoneNumber, cityName: person.cityName })
        })
            .then(response => {
                console.log('Response:', response);
            })
            .then(data => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });

    }

    const deletePerson = (personDelete) => {
        DeletePerson(personDelete.id);
        setReRender(reRender + 1);
        setCurrentPerson(initialFormState);
    }

    function DeletePerson(iddel) {
        fetch("https://localhost:44389/react/delete",
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: iddel })
            })
            .then(response => {
                console.log('Response:', response);
            });
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
                    <PersonTable persons={items} showDetails={showDetails} sort={SortPersonList}/>
                </div>
            </div>
        </div>
    )
}

export default App;
