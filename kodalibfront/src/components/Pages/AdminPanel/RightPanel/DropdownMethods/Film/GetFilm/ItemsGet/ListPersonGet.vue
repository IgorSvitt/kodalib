<template>
  <div className="list-box">
    <span className="list-name">{{ listName }}: </span>
    <ul>
      <li className="list" v-for="(item, index) in list" :key="item.id">
        Person - {{ index + 1 }}
        <br>
        <span className="list-item">
          Id: {{ item.id }}
        </span>
        <br>
        <span className="list-item">
          Name: {{ item.name }}
        </span>
      </li>
    </ul>

  </div>
</template>

<script>
export default {
  name: "ListPersonGet",
  props: {
    list: {},
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
  margin-bottom: 30px;
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

.list-item {
}
</style>