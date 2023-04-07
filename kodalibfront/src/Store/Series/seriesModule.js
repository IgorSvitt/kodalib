import axios from "axios";
import {ref} from "vue";

export const series = {
    namespaced: true,

    state: () => ({
        serial: {
            id: "",
            title: "",
            plot: "",
            year: "",
            duration: "",
            countries: [],
            genres: [],
            directors: [],
            writers: [],
            poster: "",
            ratingKoda: "",
            kinopoiskRating: "",
            youtubeTrailer: "",
            actors: [],
            voiceover: [],
        },
        films:[],
        page: 0,
        selectedCountry: '',
        selectedGenre: '',
        year: '',
        currentPage: "",
        totalPages: "",
        title: "",
    }),

    getters: {},

    mutations: {
        setId(state, id) {
            state.serial.id = id
        },

        setTitle(state, title) {
            state.serial.title = title
        },

        setPlot(state, plot) {
            state.serial.plot = plot
        },

        setDuration(state, duration) {
            state.serial.duration = duration
        },

        setYear(state, year) {
            state.serial.year = year
        },

        setGenres(state, genres) {
            const genre = ref([])
            for (let i = 0; i < genres.length; i++) {
                genre.value.push(genres[i].name.charAt(0).toUpperCase() + genres[i].name.slice(1))
            }
            state.serial.genres = genre
        },


        setCountries(state, countries) {
            const country = ref([])
            for (let i = 0; i < countries.length; i++) {
                country.value.push(countries[i].name)
            }
            state.serial.countries = country
        },

        setDirectors(state, directors) {
            const person = ref([])
            for (let i = 0; i < directors.length; i++) {
                person.value.push(directors[i].name)
            }
            state.serial.director = person
        },

        setWriters(state, writers) {
            const person = ref([])
            for (let i = 0; i < writers.length; i++) {
                person.value.push(writers[i].name)
            }
            state.serial.writer = person
        },

        setPoster(state, poster) {
            state.serial.poster = poster
        },

        setRatingKoda(state, ratingKoda) {
            state.serial.ratingKoda = ratingKoda
        },
        setKinopoiskRating(state, kinopoiskRating) {
            if(kinopoiskRating === undefined){
                kinopoiskRating = ""
            }
            state.serial.kinopoiskRating = kinopoiskRating
        },

        setYoutubeTrailer(state, youtubeTrailer) {
            state.serial.youtubeTrailer = youtubeTrailer
        },

        setActors(state, actors) {
            const actor = ref([])
            for (let i = 0; i < actors.length; i++) {
                actor.value.push(actors[i].name)
            }
            state.serial.actors = actor
        },

        setVoiceover(state, voiceovers) {
            state.serial.voiceover = voiceovers
        },

        setFilms(state, films){
            state.films.push(...films)
        },

        setPage(state, page) {
            state.page = page;
        },
        setSelectedCountry(state, selectedCountry) {
            state.selectedCountry = selectedCountry;
        },
        setSelectedGenre(state, selectedGenre) {
            state.selectedGenre = selectedGenre;
        },
        setSelectedYear(state, year) {
            state.year = year;
        },
        setSelectedTitle(state, title) {
            state.title = title;
        },
        resetFilms(state) {
            state.films = [];
            state.page = 0;
        },
        setCurrentPage(state, page) {
            state.currentPage = page;
        },
        setTotalPages(state, totalPages) {
            state.totalPages = totalPages;
        }
    },

    actions: {
        async getSerialApi({commit}, id) {
            await axios.get("http://5.44.46.158/api/series/" + id)
                .then(response => {
                    console.log(response.data.data.voiceovers)
                    commit("setId", response.data.data.id)
                    commit("setTitle", response.data.data.title)
                    commit("setPlot", response.data.data.plot)
                    commit("setYear", response.data.data.year)
                    commit("setDuration", response.data.data.duration)
                    commit("setCountries", response.data.data.countries)
                    commit("setGenres", response.data.data.genres)
                    commit("setDirectors", response.data.data.directors)
                    commit("setWriters", response.data.data.writers)
                    commit("setPoster", response.data.data.poster)
                    commit("setRatingKoda", response.data.data.kodalibRating)
                    commit("setKinopoiskRating", response.data.data.kinopoiskRating)
                    commit("setYoutubeTrailer", response.data.data.youtubeTrailer)
                    commit("setActors", response.data.data.actors)
                    commit("setVoiceover", response.data.data.voiceovers)
                })
        },
        async getSeriesApi({ commit }, { page, country, genre, year, title }) {
            try {
                let url = `http://5.44.46.158/api/series?PageSize=16&PageNumber=${page}`;
                if (country) {
                    url += `&Country=${country}`;
                }
                if (genre) {
                    url += `&Genre=${genre}`;
                }
                if (year) {
                    url += `&Year=${year}`;
                }
                if(title){
                    url += `&Title=${title}`;
                }
                const response = await axios.get(url);
                console.log(url)
                commit("setCurrentPage", response.data.data.currentPage);
                commit("setTotalPages", response.data.data.totalPages);
                commit("setFilms", response.data.data.items);
            } catch (error) {
                commit("setFilms", []);
            }
        },

    }

}