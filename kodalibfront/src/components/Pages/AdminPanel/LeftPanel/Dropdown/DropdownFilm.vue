<template>
  <a class="dropdown-btn" @click="isActiveClick">Films</a>
  <ul class="dropdown-show" :class="{ active: isActive }">
    <li><a @click="activeMethod('getFilm')" :class="{'active-method': $store.getters.activeMethodReturn === 'getFilm'}">Get</a></li>
    <li><a @click="activeMethod('createFilm')" :class="{'active-method': $store.getters.activeMethodReturn === 'createFilm'}">Create</a></li>
    <li><a @click="activeMethod('updateFilm')" :class="{'active-method': $store.getters.activeMethodReturn === 'updateFilm'}">Update</a></li>
    <li><a @click="activeMethod('deleteFilm')" :class="{'active-method': $store.getters.activeMethodReturn === 'deleteFilm'}">Delete</a></li>
  </ul>
</template>

<script>
import {ref} from "vue"
import {useStore} from "vuex"

export default {
  setup() {
    const isActive = ref(false);
    const store = useStore()

    function isActiveClick() {
      isActive.value = !isActive.value;
    }

    function activeMethod(method){
      store.commit("setActiveMethod", method)
    }
    return {
      isActive,
      isActiveClick,
      activeMethod
    };
  },
};
</script>

<style scoped>

*{
    box-sizing: border-box;
    user-select: none;
    list-style: none;
}

.active-method{
  color: #ffddcc;
  background: #392661;
  border-left-color: #ffddcc;
}

.dropdown-show{
    display: none;
}

.dropdown-show.active{
    display: block;
}

a{
    color:white;
    font-size: 18px;
    padding-left: 40px;
    font-weight: 400;
    display: block;
    width: 100%;
    border-left: 3px solid transparent;
}

a:hover {
  color: #ffddcc;
  background: #392661;
  border-left-color: #ffddcc;
}


nav ul ul li{
    line-height: 42px;
    border-bottom: none;
}

nav ul ul li a{
    font-size: 17px;
    padding-left: 80px;
}

nav ul ul {
    position: static;
    display: none;
}

</style>