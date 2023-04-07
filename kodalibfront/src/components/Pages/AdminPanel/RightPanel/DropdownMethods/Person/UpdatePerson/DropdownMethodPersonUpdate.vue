<template>
  <div class="get-method">
    <div class="title-method">Update person</div>
    <div class="get-box">
      <span class="get-box-text">Id</span>
      <p>
        <input type="text" placeholder="Id" class="get-input" v-model="id"/>
        <button class="get-box-btn" @click="getPersonById">Get</button>
      </p>
      <div v-show="activeField">
        <item-update :itemTitle="'FullName'" v-model="personInfo.name" :filmModel="personInfo.name"/>
        <item-update :itemTitle="'Birthday'" v-model="personInfo.birthtime" :filmModel="personInfo.birthtime"/>
        <item-update :itemTitle="'Image url'" v-model="personInfo.image" :filmModel="personInfo.image"/>
        <item-update :itemTitle="'Summary'" v-model="personInfo.summary" :filmModel="personInfo.summary"/>
        <item-update :itemTitle="'Death date'" v-model="personInfo.deathtime" :filmModel="personInfo.deathtime"/>
        <list-genre-and-countries-update :itemTitle="'Roles'" @items="RolesUpdate" :items="personInfo.role" />
        <div class="update-box-btn">
          <button class="update-btn" @click="updatePerson">Update</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {useStore} from "vuex";
import {ref} from "vue";

import axios from "axios";
import ListGenreAndCountriesUpdate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/UpdatePerson/ItemsUpdate/LIstCreate/ListGenreAndCountriesUpdate";
import ItemUpdate from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/UpdatePerson/ItemsUpdate/ItemUpdate";

export default {
  components: { ListGenreAndCountriesUpdate, ItemUpdate},
  setup(){

    const store = useStore();
    const id = ref("")
    const activeField = ref(false)
    const personInfo = ref(store.state.updatePersonMethod.person)

    function getPersonById() {
      store.dispatch("updatePersonMethod/getPersonApi", id.value)
          .then(() => {
            activeField.value = true
          })
          .catch(() => {
            activeField.value = false
          })
    }

    const RolesUpdate = (roles) => personInfo.value.roles = roles


    function updatePerson() {
      const config = {
        method: "put",
        url: "https://localhost:7248/api/Person/UpdatePerson?id=" + id.value,
        headers: {
          'Content-Type': 'application/json'
        },
        data: {
          "name": personInfo.value.name,
          "role": personInfo.value.role,
          "image": personInfo.value.image,
          "summary": personInfo.value.summary,
          "birthDate": personInfo.value.birthtime,
          "deathDate": personInfo.value.deathtime,
          "height": personInfo.value.height,
        },
      };
      axios(config);
    }


    return{
      id,
      RolesUpdate,
      updatePerson,
      getPersonById,
      activeField,
      personInfo
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