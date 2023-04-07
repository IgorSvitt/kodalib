import axios from "axios";
import {ref} from "vue";

export const films = {
    namespaced: true,

    state: () => ({
        film: {
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
            linkVideo: [],
            actors: []
        },
        films:[],
        page: 0,
        selectedCountry: '',
        selectedGenre: '',
        year: '',
        title: "",
        currentPage: "",
        totalPages: "",
    }),

    getters: {},

    mutations: {
        setId(state, id) {
            state.film.id = id
        },

        setTitle(state, title) {
            state.film.title = title
        },

        setPlot(state, plot) {
            state.film.plot = plot
        },

        setDuration(state, duration) {
            state.film.duration = duration
        },

        setYear(state, year) {
            state.film.year = year
        },

        setGenres(state, genres) {
            const genre = ref([])
            for (let i = 0; i < genres.length; i++) {
                genre.value.push(genres[i].name.charAt(0).toUpperCase() + genres[i].name.slice(1))
            }
            state.film.genres = genre
        },


        setCountries(state, countries) {
            const country = ref([])
            for (let i = 0; i < countries.length; i++) {
                country.value.push(countries[i].name)
            }
            state.film.countries = country
        },

        setDirectors(state, directors) {
            state.film.director = directors
        },

        setWriters(state, writers) {
            state.film.writer = writers
        },

        setPoster(state, poster) {
            state.film.poster = poster
        },

        setRatingKoda(state, ratingKoda) {
            state.film.ratingKoda = ratingKoda
        },
        setKinopoiskRating(state, kinopoiskRating) {
            if(kinopoiskRating === undefined){
                kinopoiskRating = ""
            }
            state.film.kinopoiskRating = kinopoiskRating
        },

        setYoutubeTrailer(state, youtubeTrailer) {
            state.film.youtubeTrailer = youtubeTrailer
        },

        setActors(state, actors) {
            const actor = ref([])
            for (let i = 0; i < actors.length; i++) {
                actor.value.push(actors[i].name)
            }
            state.film.actors = actor
        },

        setVoiceovers(state, voiceovers) {
            state.film.linkVideo = voiceovers
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
        async getFilmApi({commit}, id) {
            await axios.get("http://5.44.46.158/api/films/" + id)
                .then(response => {
                    console.log(response.data.data)
                    commit("setId", response.data.data.id)
                    commit("setTitle", response.data.data.title)
                    commit("setPoster", response.data.data.poster)
                    commit("setPlot", response.data.data.plot)
                    commit("setYear", response.data.data.year)
                    commit("setDuration", response.data.data.duration)
                    commit("setCountries", response.data.data.countries)
                    commit("setGenres", response.data.data.genres)
                    commit("setDirectors", response.data.data.directors)
                    commit("setWriters", response.data.data.writers)
                    commit("setRatingKoda", response.data.data.kodalibRating)
                    commit("setKinopoiskRating", response.data.data.kinopoiskRating)
                    commit("setYoutubeTrailer", response.data.data.youtubeTrailer)
                    commit("setActors", response.data.data.actors)
                    commit("setVoiceovers", response.data.data.voiceovers)
                })
        },
        async getFilmsApi({ commit }, { page, country, genre, year, title }) {
            try {
                let url = `http://5.44.46.158/api/films?PageSize=16&PageNumber=${page}`;
                if (country) {
                    url += `&Country=${country}`;
                }
                if (genre) {
                    url += `&Genre=${genre}`;
                }
                if (year) {
                    url += `&Year=${year}`;
                }
                if (title) {
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