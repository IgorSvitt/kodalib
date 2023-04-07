<template>
  <div class="item-box">
    <span class="item-box-text">{{ itemTitle }}</span>
    <ul v-for="(item, index) in listOfActors" :key="index">
      <div class="box-actor">
        <item-for-list-create :idActor="index" :actorModel="item"/>
      </div>
    </ul>

    <button class="box-btn" @click="addItem">Add</button>
    <button v-show="countItems > 0" class="box-btn remove" @click="removeItem">Remove</button>
  </div>
</template>

<script>
import ItemForListCreate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/ItemsCreate/CreateActor/ItemForListCreate";
import {ref, watch} from "vue";

export default {
  name: "ListItemCreate",
  components: {ItemForListCreate},
  props: {
    itemTitle: {}
  },
  setup(props, context) {
    const countItems = ref(0)

    const listOfActors = ref([])

    function addItem() {
      countItems.value++
      const actor = {
        id: "",
        name: "",
        role: ""
      }
      listOfActors.value.push(actor)
    }

    function removeItem() {
      if (countItems.value > 0) {
        countItems.value--
        listOfActors.value.pop()
      }
    }

    watch(listOfActors.value,(listOfActors) => {
      context.emit('actors', listOfActors)
    })

    return {
      countItems,
      addItem,
      removeItem,
      listOfActors
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
  display: block;
  padding-left: 10px;
  width: 100%;
  color: #503883;
  font-size: 20px;
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

.box-actor {
  margin-bottom: 20px;
}

</style>