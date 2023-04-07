<template>
  <div class="actors">
    <div class="actor-title">
      Актеры
    </div>
    <div class="actor" v-for="i in 5" :key="i">
      <div class="actor-img">
        <img src="@/assets/img/actors.svg">
      </div>
      <div class="actor-name">
        {{actors[i-1]}}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    actors: {
      type: Array,
      required: true,
      default: () => []
    }
  }
}
</script>

<style scoped>

.actors {
  text-align: left;
  padding-left: 55px;
}

.actor-title {
  font-size: 40px;
  color: #efefef;
  margin-bottom: 10px;
}

.actor{
  display: flex;
  justify-items: center;
  margin-bottom: 15px;
}

.actor-img{
  position: relative;
  background: #4e3883;
  border-radius: 50%;
  width: 50px;
  height: 50px;
}

.actor-img img{
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.actor-name{
  color: #efefef;
  font-size: 20px;
  margin-left: 15px;
  line-height: 50px;
}

@media (max-width: 1340px) {
  .actors {
    text-align: left;
    padding-left: 10px;
  }
}

@media (max-width: 752px){
  .actors {
    padding-left: 0;
  }

  .actor-title {
    font-size: 30px;
    color: #efefef;
    margin-bottom: 5px;
  }

  .actor{
    display: flex;
    justify-items: center;
    margin-bottom: 15px;
  }

  .actor-img{
    position: relative;
    background: #4e3883;
    border-radius: 50%;
    width: 40px;
    height: 40px;
  }

  .actor-img img{
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
  }

  .actor-name{
    color: #efefef;
    font-size: 18px;
    margin-left: 15px;
    line-height: 40px;
  }
}
</style>