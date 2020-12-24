import React from "react";

export default function Pokemones({ pokemones }) {
  if (pokemones.length === 0) return null;
  return (
    <>
      <h2>Lista de Pokemones</h2>
      <ul>
        {pokemones.map((pokemon) => {
          const { id, nombre } = pokemon;
          return <li key={id}>{nombre}</li>;
        })}
      </ul>
    </>
  );
}
