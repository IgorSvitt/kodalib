<template>
  <input type="text" v-model="url">
  <button @click="getFilms">GetFilm</button>
  <button @click="addFilms">AddFilm</button>
  <button @click="getSeries">GetSerial</button>
  <button @click="addSeries">AddSeries</button>
  <div class="container panels">
    <left-panel/>
    <right-panel/>
  </div>
</template>

<script>
import axios from "axios";
import {ref} from "vue";
import LeftPanel from "@/components/Pages/AdminPanel/LeftPanel/LeftPanel.vue";
import RightPanel from "./RightPanel/RightPanel.vue";

export default {
  components: {LeftPanel, RightPanel},
  setup() {
    const url = ref("");

    const series = ref([]);
    const films = ref([]);

    const dataSeries = ref([])
    const dataFilms = ref([])

    function addFilms() {

      const config = ({
        method: "post",
        url: "http://5.44.46.158/api/films/films",
        data: dataFilms.value,
      })
      console.log(config)
      axios(config)
    }

    function getFilms() {
      axios.get(url.value).then((responce) => {
        films.value = responce.data.results;
        getFilm()
      });
    }

    function getFilm() {
      for (let i = 0; i < films.value.length; i++) {
        const film = ref({
          kinopoiskId: "",
          title: "",
          poster: "",
          year: 0,
          plot: "",
          duration: "",
          kinopoiskRating: "",
          youtubeTrailer: "",
          countries: [],
          genres: [],
          actors: [],
          writer: [],
          director: [],
          voiceover: [],
        })
        const id = ref(dataFilms.value.findIndex(x => x.title === films.value[i].title))
        if (id.value === -1) {
          film.value.id = films.value[i].id
          film.value.kinopoiskId = films.value[i].kinopoisk_id
          film.value.title = films.value[i].title
          film.value.plot = films.value[i].material_data.description
          film.value.year = films.value[i].year
          film.value.duration = films.value[i].material_data.duration
          for (let j = 0; j < films.value[i].material_data.countries.length; j++) {
            film.value.countries.push(films.value[i].material_data.countries[j])
          }
          for (let j = 0; j < films.value[i].material_data.all_genres.length; j++) {
            film.value.genres.push(films.value[i].material_data.all_genres[j])
          }
          film.value.poster = films.value[i].material_data.poster_url
          film.value.kinopoiskRating = films.value[i].material_data.kinopoisk_rating
          film.value.voiceover.push({"name": films.value[i].translation.title, "link": films.value[i].link})

          if(film.value.kinopoiskId !== undefined){
            axios.get(`https://api.kinopoisk.dev/v1/movie/${film.value.kinopoiskId}`,  {
              headers: {
                'accept': 'application/json',
                'X-API-KEY': 'SADHXV0-EXY49EN-NTJYCE4-JVRGGEP'
              }})
                .then(responce => {
                  for (let j = 0; j < responce.data.videos.trailers.length; j++) {
                    if (responce.data.videos.trailers[j].site === "youtube") {
                      film.value.youtubeTrailer = responce.data.videos.trailers[j].url
                    }
                  }
                })
          }


          if (films.value[i].material_data.actors !== undefined) {
            for (let j = 0; j < films.value[i].material_data.actors.length; j++) {
              film.value.actors.push(films.value[i].material_data.actors[j])
            }
          }
          if (films.value[i].material_data.writers !== undefined) {
            for (let j = 0; j < films.value[i].material_data.writers.length; j++) {
              film.value.writer.push(films.value[i].material_data.writers[j])
            }
          }
          if (films.value[i].material_data.directors !== undefined) {
            for (let j = 0; j < films.value[i].material_data.directors.length; j++) {
              film.value.director.push(films.value[i].material_data.directors[j])
            }
          }

          dataFilms.value.push({
            "kinopoiskId": film.value.kinopoiskId,
            "title": film.value.title,
            "poster": film.value.poster,
            "year": film.value.year,
            "plot": film.value.plot,
            "duration": String(film.value.duration),
            "kinopoiskRating": String(film.value.kinopoiskRating),
            "youtubeTrailer": film.value.youtubeTrailer,
            "countries": film.value.countries,
            "genres": film.value.genres,
            "actors": film.value.actors,
            "writer": film.value.writer,
            "director": film.value.director,
            "voiceover": film.value.voiceover,
          })
        } else {
          dataFilms.value[id.value].voiceover.push({
            "name": films.value[i].translation.title,
            "link": films.value[i].link
          })
        }
      }
      console.log(dataFilms.value)
    }


    function getSeries() {
      axios.get(url.value).then((responce) => {
        series.value = responce.data.results;
        getSerial()
      });
    }

    function addSeries() {

      const config = ({
        method: "post",
        url: "https://localhost:7248/api/series/series",
        data: dataSeries.value,
      })
      console.log(config)
      axios(config)
    }

    function getSerial() {
      for (let i = 0; i < series.value.length; i++) {
        const serial = ref({
          kinopoiskId: "",
          poster: "",
          title: "",
          plot: "",
          year: "",
          kinopoiskRating: "",
          duration: "",
          countries: [],
          genres: [],
          director: [],
          writer: [],
          youtubeTrailer: "",
          voiceovers: [],
          actors: []
        })
        const id = ref(dataSeries.value.findIndex(x => x.title === series.value[i].title))
        if (id.value === -1) {
          serial.value.id = series.value[i].id
          serial.value.kinopoiskId = series.value[i].kinopoisk_id
          serial.value.title = series.value[i].title
          serial.value.plot = series.value[i].material_data.description
          serial.value.year = series.value[i].year
          serial.value.duration = series.value[i].material_data.duration
          for (let j = 0; j < series.value[i].material_data.countries.length; j++) {
            serial.value.countries.push(series.value[i].material_data.countries[j])
          }
          for (let j = 0; j < series.value[i].material_data.all_genres.length; j++) {
            serial.value.genres.push(series.value[i].material_data.all_genres[j])
          }
          serial.value.poster = series.value[i].material_data.poster_url
          serial.value.kinopoiskRating = series.value[i].material_data.kinopoisk_rating
          var countSeason = 0;
          var countEpisodes = 0;
          const seasons = ref([])
          for (var season in series.value[i].seasons) {
            countSeason++
            const episodes = ref([])
            var countEpisode = 0;
            for (var episode in series.value[i].seasons[season].episodes) {
              countEpisode++
              episodes.value.push({
                "numberEpisode": countEpisode,
                "videoLink": series.value[i].seasons[season].episodes[episode].link,
                "image": series.value[i].seasons[season].episodes[episode].screenshots[1]
              })
            }
            seasons.value.push({
              "numberSeason": countSeason,
              "episodes": episodes.value
            })
          }
          serial.value.voiceovers.push({
            "name": series.value[i].translation.title,
            "season": seasons.value,
            "countEpisodes": series.value[i].last_episode,
            "countSeason": series.value[i].last_season
          })

          if (series.value[i].material_data.actors !== undefined) {
            for (let j = 0; j < series.value[i].material_data.actors.length; j++) {
              serial.value.actors.push(series.value[i].material_data.actors[j])
            }
          }
          if (series.value[i].material_data.writers !== undefined) {
            for (let j = 0; j < series.value[i].material_data.writers.length; j++) {
              serial.value.writer.push(series.value[i].material_data.writers[j])
            }
          }
          if (series.value[i].material_data.directors !== undefined) {
            for (let j = 0; j < series.value[i].material_data.directors.length; j++) {
              serial.value.director.push(series.value[i].material_data.directors[j])
            }
          }

          dataSeries.value.push({
            "kinopoiskId": serial.value.kinopoiskId,
            "title": serial.value.title,
            "poster": serial.value.poster,
            "year": serial.value.year,
            "duration": String(serial.value.duration),
            "plot": serial.value.plot,
            "kinopoiskRating": String(serial.value.ratingKinopoisk),
            "youtubeTrailer": serial.value.youtubeTrailer,
            "countries": serial.value.countries,
            "genres": serial.value.genres,
            "writers": serial.value.writer,
            "directors": serial.value.director,
            "actors": serial.value.actors,
            "voiceover": serial.value.voiceovers
          })
        } else {
          countSeason = 0;
          countEpisodes = 0;
          const seasons = ref([])
          for (season in series.value[i].seasons) {
            countSeason++
            const episodes = ref([])
            countEpisode = 0;
            for (episode in series.value[i].seasons[season].episodes) {
              countEpisode++
              episodes.value.push({
                "numberEpisode": countEpisode,
                "videoLink": series.value[i].seasons[season].episodes[episode].link,
                "image": series.value[i].seasons[season].episodes[episode].screenshots[1]
              })
            }
            seasons.value.push({
              "numberSeason": countSeason,
              "episodes": episodes.value
            })
            countEpisodes = countEpisode + countEpisodes
          }
          dataSeries.value[id.value].voiceover.push({
            "name": series.value[i].translation.title,
            "season": seasons.value,
            "countEpisodes": countEpisodes,
            "countSeason": countSeason
          })
        }
      }
      console.log(dataSeries.value)
    }

    return {
      films,
      series,
      url,
      getFilms,
      getSeries,
      addFilms,
      addSeries
    };
  },
};
</script>

<style scoped>
.panels {
  margin-top: 75px;
  display: flex;
  min-height: 920px;
}
</style>
