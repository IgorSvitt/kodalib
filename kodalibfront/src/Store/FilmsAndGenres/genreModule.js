import axios from "axios";

export const genres = {
    namespaced: true,

    state: () => ({
        genres: [],
    }),

    getters: {
        genreNames(state) {
            return state.genres
                .map((genre) => genre.name.charAt(0).toUpperCase() + genre.name.slice(1))
                .sort((a, b) => a.localeCompare(b));
        },
    },

    mutations: {
        setGenres(state, genres) {
            state.genres = genres;
        },
    },

    actions: {
        async getGenresApi({ commit }) {
            const response = await axios.get("http://5.44.46.158/api/genres");
            commit("setGenres", response.data.data);
        },
    },
};