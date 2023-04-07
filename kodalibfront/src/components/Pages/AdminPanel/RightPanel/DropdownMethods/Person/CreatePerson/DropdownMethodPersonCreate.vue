<template>
  <div class="create-method">
    <div class="title-method">Create person</div>
    <item-create :itemTitle="'FullName'" v-model="person.name"/>
    <item-create :itemTitle="'Birthday'" v-model="person.birthday"/>
    <item-create :itemTitle="'Image url'" v-model="person.image"/>
    <item-create :itemTitle="'Summary'" v-model="person.summary"/>
    <item-create :itemTitle="'Birthday'" v-model="person.birthday"/>
    <item-create :itemTitle="'Death date'" v-model="person.deathdate"/>
    <item-create :itemTitle="'Height'" v-model="person.height"/>
    <list-genre-and-countries-create :itemTitle="'Roles'" @items="RolesUpdate" />
    <div class="create-box-btn">
      <button class="create-btn" @click="createPerson">Create</button>
    </div>
  </div>
</template>

<script>

import {useStore} from "vuex";
import {ref} from "vue";
import axios from "axios";
import ItemCreate from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/CreatePerson/ItemsCreate/ItemCreate";
import ListGenreAndCountriesCreate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/CreatePerson/ItemsCreate/LIstCreate/ListGenreAndCountriesCreate";


export default {
  components: {ListGenreAndCountriesCreate, ItemCreate},
  setup() {
    const store = useStore()

    const person = ref({
      id: "",
      name: "",
      summary: "",
      birthday: "",
      deathdate: "",
      roles: [],
      image: "",
      height: "",

    })

    const RolesUpdate = (roles) => person.value.roles = roles
    const filmsUpdate = (films) => person.value.films = films

    function createPerson() {
      const config = {
        method: "post",
        url: "https://localhost:7248/api/Person/CreatePerson",
        headers: {
          'Content-Type': 'application/json'
        },
        data: {
          "name": person.value.name,
          "role": person.value.roles,
          "image": person.value.image,
          "summary": person.value.summary,
          "birthDate": person.value.birthday,
          "deathDate": person.value.deathdate,
          "height": person.value.height,
        },
      };
      axios(config);
    }

    return {
      person,
      store,
      RolesUpdate,
      filmsUpdate,
      createPerson,

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