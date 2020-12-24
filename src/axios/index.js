import API from './server';

export async function getPokemones() {
    try {
        const response = await API.get('/pokemones');
        return response.data;
    } catch (error) {
        console.log(error)
    }
}

export async function createPokemon(pokemon) {
    try {
        await API.post('/pokemones', pokemon);
        return alert("Exito");
    } catch (error) {
        console.log(error);
    }
}