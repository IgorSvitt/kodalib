<template>
  <div class="get-method">
    <div class="title-method">Get person</div>
    <div class="get-box">
      <span class="get-box-text">Id</span>
      <p style="padding-bottom: 20px">
        <input type="text" placeholder="Id" class="get-input" v-model="id"/>
        <button class="get-box-btn" @click="getFilmById">Get</button>
        <br>
        <br>
        <input type="text" placeholder="Name" class="get-input" v-model="title"/>
        <button class="get-box-btn" @click="getFilmByTitle">Get by title</button>
        <item-get :item="personById.id" :itemName="'Id'"/>
        <item-get :item="personById.name" :itemName="'Name'"/>
        <item-get :item="personById.birthtime" :itemName="'Birthday'"/>
        <item-get :item="personById.deathtime" :itemName="'Death data'"/>
        <item-get :item="personById.height" :itemName="'Height'"/>
        <item-get :item="personById.summary" :itemName="'Summary'"/>
        <item-get :item="personById.image" :itemName="'Image url'"/>
        <list-get :list="personById.role" :listName="'Roles'"/>
        <list-film-get :list="personById.films" :listName="'Films'"/>
      </p>
    </div>
  </div>
</template>

<script>
import {computed, ref} from "vue";
import ItemGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/GetFilm/ItemsGet/ItemGet";
import ListGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/GetFilm/ItemsGet/ListGet";
import {useStore} from "vuex";
import ListFilmGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/GetPerson/ItemsGet/ListFilmGet";

export default {
  components: {ListFilmGet, ListGet, ItemGet},
  setup() {
    const store = useStore();
    const id = ref("")
    const title = ref("")
    const personById = computed(() => store.state.getPersonMethod.person)

    function getFilmById() {
      store.dispatch("getPersonMethod/getPersonApi", id.value)
    }

    function getFilmByTitle() {
      store.dispatch("getPersonMethod/getPersonApiByTitle", title.value)
    }

    return {
      getFilmById,
      personById,
      id,
      getFilmByTitle,
      title
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