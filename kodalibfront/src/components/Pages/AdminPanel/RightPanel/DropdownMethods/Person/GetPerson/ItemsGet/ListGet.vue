<template>
  <div class="list-box">
    <span class="list-name">{{ listName }}: </span>
  <ul>
  <li class="list" v-for="item in list" :key="item.id">
      <span class="list-item">
        {{ item }}
      </span>
  </li>
</ul>

  </div>
</template>

<script>
export default {
  name: "ListGet",
  props: {
    list: {
      type: Object,
    },
    listName: {}
  }
}
</script>

<style scoped>
.list {
  font-size: 20px;
  color: #4e3883;
  max-width: 980px;
  padding-left: 10px;
  display: block;
}

.list-name {
  font-size: 20px;
  height: 100%;
}

.list-box {
  line-height: 30px;
  margin-top: 20px;
  padding: 10px;
  border-left: 2px solid #4e3883;
  height: 100%;
  display: flex;
}

.list-item{

}
</style>