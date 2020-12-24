import React from "react";
import { createPokemon } from "../axios/index";

export default function Form() {

  const [pokemon, pokemonState] = React.useState({
    nombre: "",
    tipo: "",
    habilidades: ""
  })

  const { nombre, tipo, habilidades } = pokemon;

  function onChange(e) {
      pokemonState({
        ...pokemon,
        [e.target.name] : e.target.value
      })
  }

  function onSubmit(e) {
    e.preventDefault();
    if(nombre === "" || tipo === "" || habilidades === "") {
      alert("No se aceptan valores vacios");
      return;
    }
    createPokemon(pokemon);
  }

  return (
    <form onSubmit={onSubmit}>
      <label htmlFor="nombre">Nombre</label>
      <input
        type="text"
        id="nombre"
        name="nombre"
        onChange={onChange}
        placeholder="Nombre del Pokemon"
      />
      <label htmlFor="tipo">Tipo</label>
      <input 
        type="text" 
        id="tipo" 
        name="tipo"
        onChange={onChange} 
        placeholder="Tipo del Pokemon" 
      />
      <label htmlFor="habilidades">Habilidades</label>
      <input
        type="text"
        id="habilidades"
        name="habilidades"
        onChange={onChange}
        placeholder="Habilidades del Pokemon"
      />
      <button type="submit">Crear</button>
    </form>
  );
}
