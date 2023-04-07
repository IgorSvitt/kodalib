<template>
  <div class="item-box">
    <span class="item-box-text">{{ itemTitle }}</span>
    <ul v-for="(item, index) in listofItem" :key="index">
      <div class="box-item">
        <item-genre-and-country :itemModel="item"/>
      </div>
    </ul>
    <button class="box-btn" @click="addItem">Add</button>
    <button v-show="countItems > 0" class="box-btn remove" @click="removeItem">Remove</button>
  </div>
</template>

<script>

import {ref, watch} from "vue";
import ItemGenreAndCountry
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/ItemsCreate/LIstCreate/ItemGenreAndCountry";

export default {
  name: "ListGenreAndCountriesCreate",
  components: {ItemGenreAndCountry},
  props: {
    itemTitle: {},
  },
  setup(props, context) {
    const countItems = ref(0)

    const listofItem = ref([])


    function addItem() {
      listofItem.value
      countItems.value++
      const item = {
        name: "",
      }
      listofItem.value.push(item)
    }

    function removeItem() {
      if (countItems.value > 0) {
        countItems.value--
        listofItem.value.pop()
      }
    }

    watch(listofItem.value, (listofItem) => {
      context.emit('items', listofItem)
    })


    return {
      countItems,
      addItem,
      removeItem,
      listofItem
    }
  }
}
</script>

<style scoped>

.item-box {
  display: block;
  width: 100%;
  padding-left: 50px;
  margin-bottom: 20px;
}

.item-box-text {
  padding-left: 10px;
  color: #503883;
  font-size: 20px;
  display: block;
  width: 100%;
  margin-bottom: 20px;
}


.box-btn {
  border: none;
  border-radius: 20px;
  padding: 10px;
  width: 70px;
  color: #ffb996;
  font-size: 14px;
  font-weight: 400;
  background-color: #4e3883;
  cursor: pointer;
}

.box-btn:hover {
  color: #fff;
}

.remove {
  margin-left: 10px;
  width: 100px;
  background-color: #1B132E;
}

.box-item {
  margin-bottom: 20px;
}
</style>