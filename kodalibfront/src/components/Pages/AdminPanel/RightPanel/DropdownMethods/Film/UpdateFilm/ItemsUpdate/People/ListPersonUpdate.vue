<template>
  <div class="item-box">
    <span class="item-box-text">{{ itemTitle }}</span>
    <ul v-for="(item, index) in listofPeople" :key="index">
      <div class="box-person">
        <item-for-list-person :idPerson="index" :personModel="item"/>
      </div>
    </ul>

    <button class="box-btn" @click="addItem">Add</button>
    <button v-show="countItems > 0" class="box-btn remove" @click="removeItem">Remove</button>
  </div>
</template>

<script>
import {computed, ref, watch} from "vue";
import ItemForListPerson
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/UpdateFilm/ItemsUpdate/People/ItemForListPersonUpdate";

export default {
  name: "ListPersonUpdate",
  components: {ItemForListPerson, },
  props: {
    itemTitle: {},
    items:{
      type: Array
    }
  },
  setup(props, context) {
    const countItems = ref(props.items.length)

    const listofPeople = computed(() => props.items)


    function addItem() {
      listofPeople.value
      countItems.value++
      const person = {
        id: "",
        name:""
      }
      listofPeople.value.push(person)
    }

    function removeItem() {
      if (countItems.value > 0) {
        countItems.value--
        listofPeople.value.pop()
      }
    }

    watch(listofPeople.value,(listOfActors) => {
      context.emit('people', listOfActors)
    })


    return {
      countItems,
      addItem,
      removeItem,
      listofPeople
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

.box-person {
  margin-bottom: 20px;
}
</style>