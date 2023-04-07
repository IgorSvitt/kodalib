<template>
  <div class="create-method">
    <div class="title-method">Create film</div>
    {{film}}
    <item-create :itemTitle="'Title'" v-model="film.title"/>
    <item-create :itemTitle="'Year'" v-model="film.year"/>
    <item-create :itemTitle="'Poster url'" v-model="film.poster"/>
    <item-create :itemTitle="'Plot'" v-model="film.plot"/>
    <item-create :itemTitle="'Duration'" v-model="film.duration"/>
    <item-create :itemTitle="'Budget'" v-model="film.budget"/>
    <item-create :itemTitle="'Gross Worldwide'" v-model="film.grossWorldwide"/>
    <item-create :itemTitle="'Rating Koda'" v-model="film.ratingKoda"/>
    <item-create :itemTitle="'Thumbnail url'" v-model="film.thumbnailUrl"/>
    <item-create :itemTitle="'YouTube Trailer Id'" v-model="film.youtubeTrailer"/>
    <list-genre-and-countries-create :itemTitle="'Genres'" @items="genresUpdate" />
    <list-genre-and-countries-create :itemTitle="'Countries'" @items="countriesUpdate" />
    <list-item-create :itemTitle="'Actors'" @actors="actorsUpdate"/>
    <list-person-create :itemTitle="'Top actors'" @people="topActorUpdate"/>
    <list-person-create :itemTitle="'Writers'" @people="writersUpdate"/>
    <list-person-create :itemTitle="'Directors'" @people="directorsUpdate"/>
    <div class="create-box-btn">
      <button class="create-btn" @click="createFilm">Create</button>
    </div>
  </div>
</template>

<script>
import ItemCreate from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/ItemsCreate/ItemCreate";
import ListItemCreate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/ItemsCreate/CreateActor/ListItemCreate";
import {useStore} from "vuex";
import {ref} from "vue";
import ListPersonCreate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/ItemsCreate/People/ListPersonCreate";
import axios from "axios";
import ListGenreAndCountriesCreate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/ItemsCreate/LIstCreate/ListGenreAndCountriesCreate";

export default {
  components: {ListGenreAndCountriesCreate, ListPersonCreate, ListItemCreate, ItemCreate},
  setup() {
    const store = useStore()

    const film = ref({
      id: "",
      title: "",
      plot: "",
      year: "",
      duration: "",
      countries: [],
      genres: [],
      budget: "",
      grossWorldwide: "",
      director: [],
      writer: [],
      topActors: [],
      poster: "",
      ratingKoda: "",
      thumbnailUrl: "",
      youtubeTrailer: "",
      actors: []
    })

    const actorsUpdate = (actors) => film.value.actors = actors
    const topActorUpdate = (people) => film.value.topActors = people
    const writersUpdate = (writers) => film.value.writer = writers
    const directorsUpdate = (directors) => film.value.director = directors
    const genresUpdate = (genres) => film.value.genres = genres
    const countriesUpdate = (countries) => film.value.countries = countries

    function createFilm() {
      const config = {
        method: "post",
        url: "https://localhost:7248/api/Films/CreateFilm",
        headers: {
          'Content-Type': 'application/json'
        },
        data: {
          "title": film.value.title,
          "poster": film.value.poster,
          "year": film.value.year,
          "duration": film.value.duration,
          "plot": film.value.plot,
          "budget": film.value.budget,
          "grossWorldwide": film.value.grossWorldwide,
          "youtubeTrailer": film.value.youtubeTrailer,
          "thumbnailUrl": film.value.thumbnailUrl,
          "filmsCountriesList": film.value.countries,
          "filmsGenreList": film.value.genres,
          "actorsList": film.value.actors,
          "topActorsList": film.value.topActors,
          "writersList": film.value.writer,
          "directorList": film.value.director
        },
      };
      axios(config);
    }

    return {
      film,
      store,
      actorsUpdate,
      topActorUpdate,
      writersUpdate,
      directorsUpdate,
      createFilm,
      countriesUpdate,
      genresUpdate

    }
  }
};
</script>

<style scoped>
.title-method {
  color: #503883;
  font-size: 32px;
  text-align: center;
  font-weight: 500;
  padding: 10px;
}

.create-btn {
  border: none;
  border-radius: 20px;
  padding: 10px;
  width: 200px;
  color: #ffb996;
  font-size: 20px;
  font-weight: 400;
  background-color: #4e3883;
  cursor: pointer;
}

.create-btn:hover {
  color: #1B132E;
}

.create-box-btn {
  padding: 0 0 20px 50px;
  text-align: left;
}

</style>