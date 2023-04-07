<template>
  <div class="get-method">
    <div class="title-method">Update film</div>
    <div class="get-box">
      <span class="get-box-text">Id</span>
      <p>
        <input type="text" placeholder="Id" class="get-input" v-model="id"/>
        <button class="get-box-btn" @click="getFilmById">Get</button>

      </p>
      <div v-show="activeField">
        <item-update :itemTitle="'Title'" v-model="filmInfo.title" :filmModel="filmInfo.title"/>
        <item-update :itemTitle="'Year'" v-model="filmInfo.year" :filmModel="filmInfo.year"/>
        <item-update :itemTitle="'Poster url'" v-model="filmInfo.poster" :filmModel="filmInfo.poster"/>
        <item-update :itemTitle="'Plot'" v-model="filmInfo.plot" :filmModel="filmInfo.plot"/>
        <item-update :itemTitle="'Duration'" v-model="filmInfo.duration" :filmModel="filmInfo.duration"/>
        <item-update :itemTitle="'Budget'" v-model="filmInfo.budget" :filmModel="filmInfo.budget"/>
        <item-update :itemTitle="'Gross Worldwide'" v-model="filmInfo.grossWorldwide" :filmModel="filmInfo.grossWorldwide"/>
        <item-update :itemTitle="'Rating Koda'" v-model="filmInfo.ratingKoda" :filmModel="filmInfo.ratingKoda"/>
        <item-update :itemTitle="'Thumbnail url'" v-model="filmInfo.thumbnailUrl" :filmModel="filmInfo.thumbnailUrl"/>
        <item-update :itemTitle="'YouTube Trailer Id'" v-model="filmInfo.youtubeTrailer" :filmModel="filmInfo.youtubeTrailer"/>
        <list-genre-and-countries-update :itemTitle="'Genres'" @items="genresUpdate" :items="filmInfo.genres" />
        <list-genre-and-countries-update :itemTitle="'Countries'" @items="countriesUpdate" :items="filmInfo.countries"/>
        <list-item-update :itemTitle="'Actors'" @actors="actorsUpdate" :items="filmInfo.actors"/>
        <list-person-update :itemTitle="'Top actors'" @people="topActorUpdate" :items="filmInfo.topActors"/>
        <list-person-update :itemTitle="'Writers'" @people="writersUpdate" :items="filmInfo.writer"/>
        <list-person-update :itemTitle="'Directors'" @people="directorsUpdate" :items="filmInfo.director"/>
        <div class="update-box-btn">
          <button class="update-btn" @click="updateFilm">Update</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {useStore} from "vuex";
import {ref} from "vue";
import ItemUpdate from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/UpdateFilm/ItemsUpdate/ItemUpdate";
import ListGenreAndCountriesUpdate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/UpdateFilm/ItemsUpdate/LIstCreate/ListGenreAndCountriesUpdate";
import ListItemUpdate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/UpdateFilm/ItemsUpdate/UpdateActor/ListItemUpdate";
import ListPersonUpdate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/UpdateFilm/ItemsUpdate/People/ListPersonUpdate";
import axios from "axios";

export default {
  components: {ListPersonUpdate, ListItemUpdate, ListGenreAndCountriesUpdate, ItemUpdate},
  setup(){

    const store = useStore();
    const id = ref("")
    const activeField = ref(false)
    const filmInfo = ref(store.state.update.film)

    function getFilmById() {
      store.dispatch("update/getFilmApi", id.value)
          .then(() => {
            activeField.value = true
          })
          .catch(() => {
            activeField.value = false
          })
    }

    const actorsUpdate = (actors) => filmInfo.value.actors = actors
    const topActorUpdate = (people) => filmInfo.value.topActors = people
    const writersUpdate = (writers) => filmInfo.value.writer = writers
    const directorsUpdate = (directors) => filmInfo.value.director = directors
    const genresUpdate = (genres) => filmInfo.value.genres = genres
    const countriesUpdate = (countries) => filmInfo.value.countries = countries


    function updateFilm() {
      const config = {
        method: "put",
        url: "https://localhost:7248/api/Films/UpdateFilm?id=" + id.value,
        headers: {
          'Content-Type': 'application/json'
        },
        data: {
          "id": id.value,
          "title": filmInfo.value.title,
          "poster": filmInfo.value.poster,
          "year": filmInfo.value.year,
          "imdbRating": filmInfo.value.ratingKoda,
          "duration": filmInfo.value.duration,
          "plot": filmInfo.value.plot,
          "budget": filmInfo.value.budget,
          "grossWorldwide": filmInfo.value.grossWorldwide,
          "youtubeTrailer": filmInfo.value.youtubeTrailer,
          "thumbnailUrl": filmInfo.value.thumbnailUrl,
          "filmsCountriesList": filmInfo.value.countries,
          "filmsGenreList": filmInfo.value.genres,
          "actorsList": filmInfo.value.actors,
          "topActorsList": filmInfo.value.topActors,
          "writersList": filmInfo.value.writer,
          "directorList": filmInfo.value.director
        },
      };
      axios(config);
    }


    return{
      getFilmById,
      id,
      filmInfo,
      activeField,
      genresUpdate,
      countriesUpdate,
      actorsUpdate,
      topActorUpdate,
      writersUpdate,
      directorsUpdate,
      updateFilm
    }
  }
};
</script>

<style>
.title-method {
  color: #503883;
  font-size: 32px;
  text-align: center;
  font-weight: 500;
  padding: 10px;
}

.get-box {
  display: block;
  width: 100%;
  padding-left: 50px;
}

.get-box-text {
  padding-left: 10px;
  color: #503883;
  font-size: 20px;
}

.get-input {
  border-radius: 30px;
  border: 2px solid #503883;
  margin-top: 10px;
  padding: 10px;
  width: 25%
}

.get-box-btn {
  border: none;
  border-radius: 20px;
  padding: 10px;
  width: 100px;
  color: #ffb996;
  font-size: 16px;
  font-weight: 400;
  background-color: #4e3883;
  margin-left: 20px;
  cursor: pointer;
}

.get-box-btn:hover {
  color: #1B132E;
}

.update-btn {
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

.update-btn:hover {
  color: #1B132E;
}

.update-box-btn {
  padding: 0 0 20px 50px;
  text-align: left;
}

</style>