<template>
  <div class="get-method">
    <div class="title-method">Delete film</div>
    <div class="get-box">
      <span class="get-box-text">Id</span>
      <p>
        <input type="text" placeholder="Id" class="get-input" v-model="id"/>
        <button class="get-box-btn" @click="deleteFilmById">Delete</button>
        <br>
        <br>
        <input type="text" placeholder="Title" class="get-input" v-model="title"/>
        <button class="get-box-btn" @click="deleteFilmByTitle">Delete by title</button>
      </p>
    </div>
  </div>
</template>

<script>
import {ref} from "vue";
import axios from "axios";

export default {
  setup() {
    const url = "https://localhost:7248/api/Films/DeleteFilm?id="
    const id = ref("")

    const urlTitle = ""
    const title = ref("")

    function deleteFilmById() {
      axios.delete(url + id.value)
    }

    function deleteFilmByTitle() {
      axios.delete(urlTitle + title.value)
    }

    return {
      deleteFilmById,
      id,
      title,
      deleteFilmByTitle
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

.get-box-text{
  padding-left: 10px;
  color: #503883;
  font-size: 20px;
}

.get-input{
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