<template>
  <div class="top-title">
    <div class="name-person">
      {{ title.name }}
    </div>
    <div class="roles-person">
        <span v-for="(role, index) in title.role" :key="index">
          <span class="role" :class="{'next-role': index !== 0}">{{ role }}</span>
        </span>
    </div>
  </div>
</template>

<script>
export default {
  name: "TopTitle",
  props:{
    title:{
      type: Object
    }
  }
}
</script>

<style scoped>
.name-person {
  font-size: 42px;
  font-weight: 600;
  color: #4e3883;
}

.top-title {
  margin-bottom: 20px;
}

.roles-person{
}

.role{
  font-size: 24px;
  color: rgba(0,0,0,0.5);
}

.next-role{
  padding-left: 20px;
}
</style>