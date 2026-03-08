<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { usePulseStore } from '../stores/pulseStore'
import { PlusCircle, History } from 'lucide-vue-next'

const title = ref('')
const store = usePulseStore()
const router = useRouter()
const isCreating = ref(false)

const createPulse = async () => {
  if (!title.value) return
  isCreating.value = true
  try {
    const token = await store.createPulse(title.value)
    router.push(`/manage/${token}`)
  } finally {
    isCreating.value = false
  }
}
</script>

<template>
  <div class="max-w-2xl mx-auto py-20 px-4">
    <div class="text-center mb-12">
      <h1 class="text-5xl font-bold text-slate-900 mb-4 tracking-tight">Clearpulse</h1>
      <p class="text-lg text-slate-600">Anonymous feedback that feels safe, private, and simple.</p>
    </div>

    <div class="glass p-8 mb-12">
      <h2 class="text-xl font-semibold mb-6">Create a new Pulse</h2>
      <div class="space-y-4">
        <input 
          v-model="title"
          placeholder="e.g. 'Project Alpha Feedback' or 'My Personal Pulse'"
          class="w-full px-4 py-3 rounded-xl border-slate-200 outline-none focus:ring-2 focus:ring-safe-400 transition-all bg-white/50"
        />
        <button 
          @click="createPulse"
          :disabled="isCreating"
          class="w-full bg-safe-600 text-white font-semibold py-3 rounded-xl hover:bg-safe-700 transition-all flex items-center justify-center gap-2"
        >
          <PlusCircle :size="20" />
          {{ isCreating ? 'Creating...' : 'Start your Pulse' }}
        </button>
      </div>
    </div>

    <div v-if="store.recentPulses.length" class="space-y-4">
      <h3 class="text-sm font-semibold text-slate-400 uppercase tracking-wider flex items-center gap-2">
        <History :size="16" />
        Your Recent Pulses (Stored Locally)
      </h3>
      <div class="grid gap-3">
        <router-link 
          v-for="p in store.recentPulses" 
          :key="p.token"
          :to="`/manage/${p.token}`"
          class="glass p-4 hover:border-safe-300 transition-all cursor-pointer flex justify-between items-center"
        >
          <span class="font-medium">{{ p.title }}</span>
          <span class="text-xs text-slate-400">{{ new Date(p.createdAt).toLocaleDateString() }}</span>
        </router-link>
      </div>
    </div>
  </div>
</template>
