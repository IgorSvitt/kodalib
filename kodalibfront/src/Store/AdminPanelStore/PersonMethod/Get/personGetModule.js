import axios from "axios";

export const getPerson = {
    namespaced: true,

    state: () => ({
        person:{
            id: "",
            name: "",
            role: [],
            image: "",
            summary: "",
            birthtime: "",
            deathtime: "",
            height: "",
            films: [],
            serials: [],
            knownFor:[],
        }
    }),

    getters: {},

    mutations: {
        setId(state, id) {
            state.person.id = id
        },
        setName(state, name) {
            state.person.name = name
        },
        setRole(state, roles) {
            state.person.role = roles
        },
        setImage(state, image) {
            state.person.image = image
        },
        setSummary(state, summary) {
            state.person.summary = summary
        },
        setBirth(state, birth) {
            state.person.birthtime = birth
        },
        setHeight(state, height) {
            state.person.height = height
        },
        setDeath(state, death) {
            state.person.deathtime = death
        },
        setFilms(state, films) {
            state.person.films = films
        },
        setSerials(state, serials) {
            state.person.serials = serials
        },
        setKnow(state, knowFor) {
            state.person.knownFor = knowFor
        },
    },

    actions: {
        getPersonApi({commit}, id) {
            axios.get("https://localhost:7248/api/Person/GetPerson/" + id)
                .then(responce => {
                    commit("setId",responce.data.id)
                    commit("setName",responce.data.name)
                    commit("setRole",responce.data.role)
                    commit("setImage",responce.data.image)
                    commit("setSummary",responce.data.summary)
                    commit("setBirth",responce.data.birthDate)
                    commit("setDeath",responce.data.deathDate)
                    commit("setHeight",responce.data.height)
                    commit("setFilms",responce.data.films)
                })
                .catch(error => {
                    console.log(error.response.status)
                })
        },
        getPersonApiByTitle({commit}, title) {
            axios.get("http://localhost:8010/api/persons/" + title)
                .then(responce => {
                    commit("setId",responce.data[0].id)
                    commit("setName",responce.data[0].name)
                    commit("setRole",[])
                    commit("setImage",responce.data[0].image)
                    commit("setSummary",responce.data[0].summary)
                    commit("setBirth",responce.data[0].birthDate)
                    commit("setDeath",responce.data[0].deathDate)
                    commit("setHeight",responce.data[0].height)
                    commit("setFilms",[])
                })
                .catch(error => {
                    console.log(error.response.status)
                })
        }

    }

}