import axios from "axios";

export const country = {
    namespaced: true,

    state: () => ({
        country: [],
    }),

    getters: {
        countryNames(state) {
            return state.country
                .map((country) => country.name.charAt(0).toUpperCase() + country.name.slice(1))
                .sort((a, b) => a.localeCompare(b));
        },
    },

    mutations: {
        setCountries(state, country) {
            state.country = country;
        },
    },

    actions: {
        async getCountriesApi({ commit }) {
            const response = await axios.get("http://5.44.46.158/api/countries");
            commit("setCountries", response.data.data);
        },
    },
};