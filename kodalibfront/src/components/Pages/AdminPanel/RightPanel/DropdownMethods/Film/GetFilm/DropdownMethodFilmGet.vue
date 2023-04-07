<template>
  <div class="get-method">
    <div class="title-method">Get film</div>
    <div class="get-box">
      <span class="get-box-text">Id</span>
      <p style="padding-bottom: 20px">
        <input type="text" placeholder="Id" class="get-input" v-model="id"/>
        <button class="get-box-btn" @click="getFilmById">Get</button>
        <item-get :item="filmById.id" :itemName="'Id'"/>
        <item-get :item="filmById.title" :itemName="'Title'"/>
        <item-get :item="filmById.year" :itemName="'Year'"/>
        <item-get :item="filmById.poster" :itemName="'Poster url'"/>
        <item-get :item="filmById.plot" :itemName="'Plot'"/>
        <item-get :item="filmById.duration" :itemName="'Duration'"/>
        <item-get :item="filmById.budget" :itemName="'Budget'"/>
        <item-get :item="filmById.grossWorldwide" :itemName="'Gross Worldwide'"/>
        <item-get :item="filmById.ratingKoda" :itemName="'Rating Koda'"/>
        <item-get :item="filmById.thumbnailUrl" :itemName="'Thumbnail url'"/>
        <item-get :item="filmById.youtubeTrailer" :itemName="'YouTube Trailer Id'"/>
        <list-get :list="filmById.countries" :listName="'Countries'"/>
        <list-get :list="filmById.genres" :listName="'Genres'"/>
        <list-actor-get :list="filmById.actors" :listName="'Actors'"/>
        <list-person-get :list="filmById.topActors" :listName="'Top actors'"/>
        <list-person-get :list="filmById.writer" :listName="'Writes'"/>
        <list-person-get :list="filmById.director" :listName="'Directors'"/>
      </p>
    </div>
  </div>
</template>

<script>
import {computed, ref} from "vue";
import ItemGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/GetFilm/ItemsGet/ItemGet";
import ListGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/GetFilm/ItemsGet/ListGet";
import ListActorGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/GetFilm/ItemsGet/ListActorGet";
import ListPersonGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/GetFilm/ItemsGet/ListPersonGet";
import {useStore} from "vuex";

export default {
  components: {ListPersonGet, ListActorGet, ListGet, ItemGet},
  setup() {
    const store = useStore();
    const id = ref("")
    const filmById = computed(() => store.state.get.film)

    function getFilmById() {
      store.dispatch("get/getFilmApi", id.value)

    }

    return {
      getFilmById,
      filmById,
      id,
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


</style>