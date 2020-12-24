import React from "react";
import { Link, BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { getPokemones } from "./axios/index";
import Form from "./components/Form";
import Pokemones from "./components/Pokemones";

function App() {
  const [pokemones, setPokemones] = React.useState([]);

  React.useEffect(() => {
    async function getAllPokemones() {
      const result = await getPokemones();
      setPokemones(result);
    }
    getAllPokemones();
    //eslint-disable-next-line
  }, []);

  return (
    <>
      <h1>Pokemones</h1>
      <Router>
        <Switch>
          <Route exact path="/crear" component={Form} />
        </Switch>
        <Link to={"/crear"}>Crear pokemon</Link>
      </Router>
      <Pokemones pokemones={pokemones} />
    </>
  );
}

export default App;
